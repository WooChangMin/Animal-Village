using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    //인벤토리 종료시 발생하는 이벤트
    public UnityAction OnInventoryClose;
    public UnityAction OnInventoryOpen;
    //움직임속도
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float rotateSpeed;

    private float curSpeed;
    private int userGold;

    //인벤토리용
    [SerializeField] Transform dropPoint;
    [SerializeField] LayerMask itemMask;
    public InventoryObject inventory;
    private bool activeInventory = false;

    private ParticleSystem runEffect;

    //달리고있는지 유무확인
    private bool isRun;

    //인벤토리가 열려있을때 다른행동 정지

    //줍는 중인경우! 다른행동정지
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
        if (!isPick || !activeInventory)
            Move();

        if (activeInventory)
            InventoryCursor();
    }

    private void InventoryCursor()
    {

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
        moveDir = new Vector3 (value.Get<Vector2>().x, 0 , value.Get<Vector2>().y);
    }

    //움직임 구현 (뛸때 걸을떄 속도조절)
    private void Move()
    {
        if (!activeInventory & !isPick)
        {
            runEffect.Play();
            if (moveDir.magnitude == 0)
            {
                curSpeed = Mathf.Lerp(curSpeed, 0f, 0.5f);
                runEffect.Stop();
            }
            else if (isRun == true)
            {
                curSpeed = Mathf.Lerp(curSpeed, runSpeed, 0.03f);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-moveDir), Time.deltaTime * rotateSpeed);
            }
            else
            {
                curSpeed = Mathf.Lerp(curSpeed, moveSpeed, 0.05f);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-moveDir), Time.deltaTime * rotateSpeed);
            }
            
            controller.Move(-moveDir* curSpeed * Time.deltaTime);
            animator.SetFloat("Speed", curSpeed);
        }
        else
        {

        }
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

    //Coroutine ItemPickUpRoutine; 아이템 픽업 코루틴
    private IEnumerator ItemPickUp()
    {
        while (true)
        {
            if (isPick && !activeInventory)
            { 
                //발위치에서 원형의 오버랩스피어사용                    
                Collider[] colliders = Physics.OverlapSphere(dropPoint.position, 0.7f, itemMask);

                //충돌체가 없을때?
                if (colliders.Length <= 0)
                {
                    yield return null;
                    isPick = false;
                }
                //충돌체가 있을때
                else
                {
                    Item var = colliders[0].gameObject.GetComponent <Item>();   
                    animator.SetTrigger("IsPickUp");
                    Destroy(colliders[0].gameObject);
                    inventory.AddItem(var.item, 1);  //아이템 추가

                    yield return new WaitForSeconds(1f); // 애니메이션 구현 시간
                    isPick = false;
                }
            }
            yield return null;
        }
    }

    //인벤토리 초기화! scriptableObject값
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    //아이템 픽업 입력구현
    private void OnItemPickUp(InputValue value)
    {
        isPick = true;
        ItemPickUp();
    }

    //인벤토리 함수로 activeInventory의 bool값을 바꾸면서 UI매니저에서 구현
    private void Inventory()
    {
        activeInventory = !activeInventory;
        if (activeInventory)
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

    //인벤토리 입력들어왔을때 함수실행
    private void OnInventory(InputValue value)
    {
        Inventory();
    }

    //발 밑 먼지날리는 파티클
    private void Particle()
    {
        Component particle = this.GetComponentInChildren<ParticleSystem>();
    }
    
    /*//줍는 범위 표현
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(dropPoint.position, 0.5f);
    }*/
}
