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
    private float curSpeed;

    //�κ��丮��
    public GameObject inventory;
    private bool activeInventory = false;

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
       
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        // �������� �������� ��� �����ӿ� ������ �ȹް� ����
        Fall();
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
        if(moveDir.magnitude == 0)
        {
            curSpeed = Mathf.Lerp(curSpeed, 0f, 0.5f);
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

    private void ItemPickUp()
    {
        animator.SetTrigger("IsPickUp");
    }

    private void OnItemPickUp(InputValue value)
    {
        ItemPickUp();
    }
    private void Inventory()
    {
        activeInventory = !activeInventory;
        inventory.SetActive(activeInventory);  
    }

    private void OnInventory(InputValue value)
    {
        Inventory();
        //inventory
    }
}
