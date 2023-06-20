using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    //움직임속도
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform dropPoint;
    [SerializeField]private LayerMask itemMask;

    private float curSpeed;

    //인벤토리용
    public GameObject inventory;
    private bool activeInventory = false;

    private ParticleSystem runEffect;

    //달리고있는지 유무확인
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
        // 떨어지는 움직임의 경우 프레임에 영향을 안받게 구현
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

    //움직임시 방향을 입력받음 
    private void OnMove(InputValue value)
    {
        iswalk = true;
        moveDir = new Vector3 (value.Get<Vector2>().x, 0 , value.Get<Vector2>().y);
    }

    //움직임 구현 (뛸때 걸을떄 속도조절)
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

    // 중력 조절
    private void Fall() 
    {
        controller.Move(Vector3.up * Physics.gravity.y * Time.deltaTime);
    }
    
    // 키다운시 속도 isRun true로반환
    private void OnRun(InputValue value)
    {
        isRun = value.isPressed;
    }

    //TODO : 공격구현예정
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

                    yield return new WaitForSeconds(0.9f); // 애니메이션 구현 시간
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
