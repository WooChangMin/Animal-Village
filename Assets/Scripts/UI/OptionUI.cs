using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionUI : BaseUI
{
    public UnityAction<int> OnChangeDialogue;
    private int order;
    public bool isOpen;


    protected override void Awake()
    {
        base.Awake();
        order = 0;
    }
    private void OnEnable()
    {
        isOpen = true;
        GameObject playerObj = GameObject.Find("Player");
        playerObj.GetComponent<PlayerInput>().enabled = false;
        Refresh();
    }

    private void OnDisable()
    {
        isOpen = false;
        GameObject playerObj = GameObject.Find("Player");
        playerObj.GetComponent<PlayerInput>().enabled = true;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            order = (order+1)%3;
            Refresh();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            order = (order-1)%3;
            Refresh();
        }

        if(Input.GetKeyDown(KeyCode.G) && isOpen)
        {
            SelectOption();
        }
    }

    //� ����� Ư�������� outline�� enable ������ �Ǻ�
    private void Refresh()
    {
        Outline[] outlines = gameObject.GetComponentsInChildren<Outline>();
        for (int i = 0; i<3; i++)
        {
            if(i== order)
            {
                outlines[i].enabled = true;
            }
            else
            {
                outlines[i].enabled = false;
            }
        }
    }

    // Ư�� option�� �������� �� �̺�Ʈ �߻��� ��Ȱ��ȭ
    private void SelectOption()
    {
        OnChangeDialogue.Invoke(order);
        gameObject.SetActive(false);
    }
}