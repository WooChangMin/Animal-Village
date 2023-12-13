using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class PlayerControll : MonoBehaviour
{
    //�κ��丮 ����� �߻��ϴ� �̺�Ʈ
    public UnityAction OnInventoryClose;
    public UnityAction OnInventoryOpen;
    //�����Ӽӵ�
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float rotateSpeed;

    private float curSpeed;
    private int userGold;

    //�κ��丮��
    [SerializeField] Transform dropPoint;
    [SerializeField] LayerMask itemMask;

    public InventoryObject inventory;

    private ParticleSystem curParticle;

    //�޸����ִ��� ����Ȯ��
    private bool isRun = false;
    //�κ��丮�� ���������� �ٸ��ൿ ����
    private bool onInventory = false;
    //�ݴ� ���ΰ��! �ٸ��ൿ����
    private bool isPick = false;

    private Animator animator;
    private Vector3 moveDir;
    private CharacterController controller;

    ParticleSystem[] myPartList;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        myPartList = GetComponentsInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (!isPick || !onInventory)
            Move();

        if (onInventory)
            InventoryCursor();
    }

    private void InventoryCursor()
    {

    }

    private void FixedUpdate()
    {
        // �������� �������� ��� �����ӿ� ������ �ȹް� ����
        Fall();
    }

    private void OnEnable()
    {
        StartCoroutine(ItemPickUp());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void OnTriggerStay(Collider other)
    {
        
    }

    //�����ӽ� ������ �Է¹��� 
    private void OnMove(InputValue value)
    {
        moveDir = new Vector3 (value.Get<Vector2>().x, 0 , value.Get<Vector2>().y);
    }

    //������ ���� (�۶� ������ �ӵ�����)
    private void Move()
    {
        //Particle System Management
        ParticleManage();

        if (!onInventory & !isPick)
        {
            //�Է°��� ������
            if (moveDir.magnitude == 0)
            {
                curSpeed = Mathf.Lerp(curSpeed, 0f, 0.5f);
            }
            
            //�޸���
            else if (isRun == true)
            {
                curSpeed = Mathf.Lerp(curSpeed, runSpeed, 0.03f);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-moveDir), Time.deltaTime * rotateSpeed);
            }

            //������
            else
            {
                curSpeed = Mathf.Lerp(curSpeed, moveSpeed, 0.05f);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-moveDir), Time.deltaTime * rotateSpeed);
            }
            
            controller.Move(-moveDir* curSpeed * Time.deltaTime);
            animator.SetFloat("Speed", curSpeed);
        }
    }

    private void ParticleManage()
    {
        if(curParticle !=null)
            curParticle.Stop();

        if(curSpeed > 6)
        {
            // **** run Effect ****
            myPartList[0].gameObject.SetActive(false);
            myPartList[1].gameObject.SetActive(true);
            curParticle = myPartList[1];
        }

        else if(curSpeed > 2)
        {
            // **** walk Effect ****
            myPartList[0].gameObject.SetActive(true);
            myPartList[1].gameObject.SetActive(false);
            curParticle = myPartList[0];
        }

        else
        {
            // **** none Effect ****
            myPartList[0].gameObject.SetActive(false);
            myPartList[1].gameObject.SetActive(false);
            curParticle = null;
        }

        if (curParticle!=null)
            curParticle.Play();
    }

    // �߷� ���� *FixedUpdate�� ����
    private void Fall() 
    {
        controller.Move(Vector3.up * Physics.gravity.y * Time.deltaTime);
    }
    
    // Ű�ٿ�� �ӵ� isRun true�ι�ȯ
    private void OnRun(InputValue value)
    {
        isRun = value.isPressed;
    }

    //TODO : ���ݱ�������
    private void OnAttack(InputValue value)
    {
        Attack();
    }
    
    private void Attack()
    {

    }

    //Coroutine ItemPickUpRoutine; ������ �Ⱦ� �ڷ�ƾ
    private IEnumerator ItemPickUp()
    {
        while (true)
        {
            if (isPick && !onInventory)
            { 
                //����ġ���� ������ ���������Ǿ���                    
                Collider[] colliders = Physics.OverlapSphere(dropPoint.position, 0.7f, itemMask);

                //�浹ü�� ������?
                if (colliders.Length <= 0)
                {
                    yield return null;
                    isPick = false;
                }
                //�浹ü�� ������
                else
                {
                    Item var = colliders[0].gameObject.GetComponent<Item>();   
                    animator.SetTrigger("IsPickUp");
                    Destroy(colliders[0].gameObject);
                    inventory.AddItem(var.item, 1);  //������ �߰�

                    yield return new WaitForSeconds(1f); // �ִϸ��̼� ���� �ð�
                    isPick = false;
                }
            }
            yield return null;
        }
    }

    //�κ��丮 �ʱ�ȭ! scriptableObject��
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    //������ �Ⱦ� �Է±���
    private void OnItemPickUp(InputValue value)
    {
        isPick = true;
        ItemPickUp();
    }

    //�κ��丮 �Լ��� onInventory�� bool���� �ٲٸ鼭 UI�Ŵ������� ����
    private void Inventory()
    {
        onInventory = !onInventory;
        if (onInventory)
        {
            animator.SetBool("IsOnInven", true);
            OnInventoryOpen?.Invoke();
            GameManager.UI.OpenInventoryUI();
        }
        else
        {
            animator.SetBool("IsOnInven", false);
            OnInventoryClose?.Invoke();  
            GameManager.UI.CloseInventoryUI();
            GameManager.UI.CloseSelectUI();
        }
    }

    //�κ��丮 �Էµ������� �Լ�����
    private void OnInventory(InputValue value)
    {
        Inventory();
    }

    //�� �� ���������� ��ƼŬ
    private void Particle()
    {
        Component particle = this.GetComponentInChildren<ParticleSystem>();
    }
    
    /*//�ݴ� ���� ǥ��
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(dropPoint.position, 0.5f);
    }*/
}
