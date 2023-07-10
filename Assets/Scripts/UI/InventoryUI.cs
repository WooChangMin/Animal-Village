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
//using UnityEngine.UIElements;

public class InventoryUI : BaseUI //IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public InventoryObject Inventory;
    private int dataOrder;
    private int selectUIOrder = 0;
    private bool OnSelectUI;
    private Vector3 cursorOffset = new Vector3 (50f, -50f, 0);
    private Vector3 SelectUIOffset = new Vector3(180f, -80f, 0);
    private Vector2 moveDir;

    int number;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        dataOrder = 0;
        number = 0;
        Inventory.OnInventoryChanged += Refresh;
        FindObjectOfType<PlayerControll>().OnInventoryClose += CursorCancel;

        //PlayerControll.OnInventoryShutDown += null;
        Refresh();
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChanged -= Refresh;
        //FindObjectOfType<PlayerControll>().OnInventoryShutDown -= CursorCancel;
        //PlayerControll.OnInventoryShutDown -= null;
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
    }

    //�����˾�â �޾�����
    public void OnCursorSelect(InputValue value)
    {
        CursorSelect();
    }

    //���� �˾�â ����
    public void CursorSelect()
    {
        if (OnSelectUI)
        {
            //�����˾�â���� �ൿ�� ����������?
            GameManager.UI.SelectUI.transform.GetChild(number).GetComponentInChildren<BaseUI>().Actions(selectUIOrder % 2);
            //[selectUIOrder%2].onClick.Invoke();
        }
        else
        {
            if (Inventory.Container.Count <= dataOrder)
            {
                return;
            }
            OnSelectUI = true;
            GameManager.UI.OpenSelectUI(Inventory.Container[dataOrder].item.type);
            CursorPosition();
        }
    }

    //Ŀ�� �����ӽ� Ŀ���� ��ġ���� ǥ��
    public void CursorPosition()
    {
        if (Inventory.Container.Count <= dataOrder)
            number = 0;
        else number = (int)Inventory.Container[dataOrder].item.type;
        
        if (OnSelectUI)
        {
            GameObject.Find("Cursor").transform.position = GameManager.UI.SelectUI.transform.GetChild(number).GetChild((Mathf.Abs(selectUIOrder))%2).position + SelectUIOffset;
        }
        else
        {
            if (dataOrder == 0)
            {
                GameObject.Find("Cursor").transform.position = new Vector3(1185.49f, 726.36f, -2.63f) + cursorOffset;
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
    public void CursorCancel()
    {
        OnSelectUI = false;
        selectUIOrder = 0;
        GameManager.UI.CloseSelectUI();
    }
    public void OnCursorCancel(InputValue value)
    {
        CursorCancel();
        CursorPosition();
    }

    //Ŀ���� ������ ����
    public void CursorMove()
    {
        if (!OnSelectUI)
        {
            if(moveDir.x > 0)
            {
                if (dataOrder % 4 == 3  )
                {
                    dataOrder -= 3;
                }
                else
                {
                    dataOrder += 1 ;
                }
                Refresh();
            }
            
            if(moveDir.x < 0)
            {
                if (dataOrder % 4 == 0)
                {
                    dataOrder += 3;
                }
                else
                {
                    dataOrder -= 1;
                }
                Refresh();
            }
            
            if(moveDir.y > 0)
            {
                if (dataOrder / 4 == 0)
                {
                    dataOrder += 12;
                }
                else
                {
                    dataOrder -= 4;
                }
                Refresh();
            }
            
            if(moveDir.y < 0)
            {
                if (dataOrder / 4 == 3)
                {
                    dataOrder -= 12;
                }
                else
                {
                    dataOrder += 4;
                }
                Refresh();
            }
        }
        else
        {
            if(moveDir.y > 0)
            {
                selectUIOrder -= 1 ;
                Refresh();
            }
            if(moveDir.y < 0)
            {
                selectUIOrder += 1 ;
                Refresh();
            }
        }
    }
    public void OnCursorMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
        CursorMove();
    }
}