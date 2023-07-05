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

    //어떤 대상을 특정중인지 outline의 enable 유무로 판별
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

    // 특정 option을 선택했을 때 이벤트 발생후 비활성화
    private void SelectOption()
    {
        OnChangeDialogue.Invoke(order);
        gameObject.SetActive(false);
    }
}