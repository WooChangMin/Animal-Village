using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.ComponentModel;
using UnityEngine.InputSystem;
using static Unity.VisualScripting.Metadata;
using TreeEditor;
using JetBrains.Annotations;

public class InventoryUI : BaseUI //IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public InventoryObject Inventory;
    private int dataOrder;
    private int selectUIOrder;
    private bool OnSelectUI;
    private Vector3 cursorOffset = new Vector3 (50, -50, 0);


    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        dataOrder = 0;
        Inventory.OnInventoryChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChanged -= Refresh;
    }

    //�κ��丮�� �������� �κ��丮 ����ȭ
    public void Refresh()
    {
        CursorPosition();
        ItemHighlight();
      
        //�κ��丮�� �������� ����� �����۵��� �������� ����
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            //������ �̹�������
            transform.GetChild(i).GetComponentsInChildren<Image>()[1].sprite = Inventory.Container[i].item.itemImage;
            //������ ���� ����
            transform.GetChild(i).GetComponentInChildren<Text>().text = Inventory.Container[i].amount.ToString();
        }


        /*
        for (int i = 0; i < 16; i++)
        {
            Slots[i] = myChildren[(i*3)+2];
        }
        for (int i=0; i< Inventory.Container.Count ; i++)
        {
            Slots[i].GetComponentInChildren<Image>().sprite = Inventory.Container[i].item.itemImage;
            Slots[i].Tex= Inventory.Container[i].amount;
            
        }

        Transform[] myChildren = Inventory.GetComponentsInChildren<Transform>();
        *//*Slot[] slots  = this.GetComponentsInChildren<Slot>();
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            slots[1].text = "13234";
        }*/
    }
    //�����˾�â �޾�����
    public void OnCursorSelect(InputValue value)
    {
        CursorSelect();
    }

    //���� �˾�â ����
    public void CursorSelect()
    {
        OnSelectUI = true;
        if (Inventory.Container.Count <= dataOrder)
        {
            return;
        }
        OnSelectUI = true;
        GameManager.UI.OpenSelectUI(Inventory.Container[dataOrder].item.type);
    }

    //Ŀ�� �����ӽ� Ŀ���� ��ġ���� ǥ��
    public void CursorPosition()
    {
        if (OnSelectUI)
        {
            GameObject.Find("Cursor").transform.position = GameObject.Find("SelectUI").transform.GetChild(1).position;
        }
        else
        {
            if (dataOrder == 0)
            {
                GameObject.Find("Cursor").transform.position = new Vector3(330.00f, 851.00f, 0)+ cursorOffset;
            }
            else
            {
                GameObject.Find("Cursor").transform.position = transform.GetChild(dataOrder).position + cursorOffset;
            }        
        }
    }


    //������ ���� ����
    public void ItemHighlight()
    {
        Outline[] slots = transform.GetComponentsInChildren<Outline>();
        foreach (Outline slot in slots)
        {
            slot.enabled = false;
        }
        slots[dataOrder].enabled = true;
    }

    // esc�� ������� ���� �˾�â ����
    public void OnCursorCancel(InputValue value)
    {
        OnSelectUI = false;
        GameManager.UI.CloseSelectUI();
    }

    public void CursorMove()
    {

    }
    //Ŀ���� ������ ����
    public void OnCursorMove(InputValue value)
    {
        if (!OnSelectUI)
        {
            if(value.Get<Vector2>().x > 0)
            {
                if (dataOrder % 8 == 7  )
                {
                    dataOrder -= 7;
                }
                else
                {
                    dataOrder += 1 ;
                }
                Refresh();
            }
            
            if(value.Get<Vector2>().x < 0)
            {
                if (dataOrder % 8 == 0)
                {
                    dataOrder += 7;
                }
                else
                {
                    dataOrder -= 1;
                }
                Refresh();
            }
            
            if(value.Get<Vector2>().y > 0)
            {
                if (dataOrder / 8 == 0)
                {
                    dataOrder += 8;
                }
                else
                {
                    dataOrder -= 8;
                }
                Refresh();
            }
            
            if(value.Get<Vector2>().y < 0)
            {
                if (dataOrder / 8 == 0)
                {
                    dataOrder += 8;
                }
                else
                {
                    dataOrder -= 8;
                }
                Refresh();
            }
        }
        else 
        {
            selectUIOrder = 0;
            if(value.Get<Vector2>().y > 0)
            {
                selectUIOrder -= 1 ;
            }
            if(value.Get<Vector2>().y > 0)
            {
                selectUIOrder += 1 ;
            }
        }
    }
}