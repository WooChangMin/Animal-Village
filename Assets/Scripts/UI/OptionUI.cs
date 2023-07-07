using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

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
            if (order > 1)
                order = 2;
            else
            {
                order++;
            }
            Refresh();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (order < 1)
                order = 0;
            else
            {
                 order--;
            }
            Refresh();
        }

        if(isOpen && Input.GetKeyDown(KeyCode.Space))
        {
            SelectOption();
        }
    }

    //� ����� Ư�������� outline�� enable ������ �Ǻ�
    private void Refresh()
    {
        TMP_Text[] texts = gameObject.GetComponentsInChildren<TMP_Text>();
        for (int i = 0; i<3; i++)
        {
            if(i== order)
            {
                texts[i].fontStyle = FontStyles.Underline;
                //outlines[i].enabled = true;
            }
            else
            {
                texts[i].fontStyle = FontStyles.Normal;
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