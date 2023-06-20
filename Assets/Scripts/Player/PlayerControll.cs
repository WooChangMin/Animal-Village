using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    //�����Ӽӵ�
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform dropPoint;
    [SerializeField]private LayerMask itemMask;

    private float curSpeed;

    //�κ��丮��
    public GameObject inventory;
    private bool activeInventory = false;

    private ParticleSystem runEffect;

    //�޸����ִ��� ����Ȯ��
    private bool iswalk;
    private bool isRun;
    private bool isPick = false;

    private Animator animator;
    private Vector3 moveDir;
    private CharacterController controller;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        runEffect = GetComponentInChildren<ParticleSystem>();

    }

    private void Update()
    {
        if (!isPick)
            Move();
            
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
        iswalk = true;
        moveDir = new Vector3 (value.Get<Vector2>().x, 0 , value.Get<Vector2>().y);
    }

    //������ ���� (�۶� ������ �ӵ�����)
    private void Move()
    {
        runEffect.Play();
        if (moveDir.magnitude == 0)
        {
            curSpeed = Mathf.Lerp(curSpeed, 0f, 0.5f);
            runEffect.Stop();
        }
        else if (isRun == true)
        {
            curSpeed = Mathf.Lerp(curSpeed, runSpeed, 0.5f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-moveDir), Time.deltaTime * rotateSpeed);
        }
        else
        {
            curSpeed = Mathf.Lerp(curSpeed, moveSpeed, 0.5f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-moveDir), Time.deltaTime * rotateSpeed);
        }
        
        controller.Move(-moveDir* curSpeed * Time.deltaTime);
        animator.SetFloat("Speed", curSpeed);
    }

    // �߷� ����
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

    //Coroutine ItemPickUpRoutine;
    private IEnumerator ItemPickUp()
    {
        while(true)
        {
            if (isPick)
            {
                Collider[] colliders = Physics.OverlapSphere(dropPoint.position, 0.5f, itemMask);

                if (colliders.Length <= 0)
                {
                    yield return null;
                    isPick = false;
                }
                else
                {
                    animator.SetTrigger("IsPickUp");
                    Destroy(colliders[0].gameObject);

                    yield return new WaitForSeconds(0.9f); // �ִϸ��̼� ���� �ð�
                    isPick = false;

                }
            }
            yield return null;
        }
    }

    private void OnItemPickUp(InputValue value)
    {
        isPick = true;
        ItemPickUp();
    }

    private void Inventory()
    {
        activeInventory = !activeInventory;
        if (activeInventory)
        {
            GameManager.UI.OpenInventoryUI();
        }
        else
        {
            GameManager.UI.CloseInventoryUI();
        }
    }

    private void OnInventory(InputValue value)
    {
        Inventory();
    }

    private void Particle()
    {
        Component particle = this.GetComponentInChildren<ParticleSystem>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(dropPoint.position, 0.5f);
    }
}
