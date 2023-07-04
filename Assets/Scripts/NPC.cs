using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public ConversationScript scripts;
    

    CharacterController controller;

    private float moveSpeed = 3f;
    private float range = 8f;

    private Vector3 targetPosition;
    private Animator animator;

    private int scriptOrder=0;


    private void Awake()
    {
        animator = GetComponent<Animator>();    
        controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        FindPlayer();
    }

    private void Update()
    {
        Move();  
    }


    public void Interact()
    {
        Talk(scriptOrder);
    }

    public void Talk(int sequence)
    {
        string dialogue = scripts.container[scriptOrder];
        GameManager.UI.OpenConversationUI(dialogue);
    }
    private void Move()
    {
        if (FindPlayer())
        {
            if(Vector3.Distance(targetPosition, transform.position) > 2.5f)
                controller.Move((targetPosition - transform.position).normalized * moveSpeed * Time.deltaTime);
            else
            {
                animator.SetBool("isFollow", false);
            }
        }
    }
    private bool FindPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider thing in colliders)
        {
            if (thing.CompareTag("Player"))
            {
                animator.SetBool("isFollow", true);
                targetPosition = thing.transform.position;
                transform.LookAt(targetPosition);
                
                return true;
            }
        }
        return false;
    }
}