using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float rotateSpeed;

    private bool isRun;

    private Animator animator;
    private Vector3 moveDir;
    private CharacterController controller;
    private float curSpeed;


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
        Fall();
    }

    private void OnMove(InputValue value)
    {
        moveDir = new Vector3 (value.Get<Vector2>().x, 0 , value.Get<Vector2>().y);
    }

    private void Move()
    {
        if (isRun)
        {
            curSpeed = Mathf.Lerp(curSpeed, runSpeed, 0.5f);
            animator.SetFloat("Speed", curSpeed);
        }
        else
        {
            curSpeed = moveSpeed;
            animator.SetFloat("Speed", curSpeed);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-moveDir), Time.deltaTime * rotateSpeed);
        controller.Move(-moveDir * curSpeed * Time.deltaTime);
    }

    private void Fall()
    {
        controller.Move(Vector3.up * Physics.gravity.y * Time.deltaTime);
    }
    
    private void OnRun(InputValue value)
    {
        isRun = value.isPressed;
    }

    private void OnAttack(InputValue value)
    {
        Attack();
    }
    
    private void Attack()
    {

    }
}
