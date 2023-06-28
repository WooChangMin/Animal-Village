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

    //인벤토리를 열때마다 인벤토리 최적화
    public void Refresh()
    {
        CursorPosition();
        ItemHighlight();
      
        //인벤토리를 열때마다 드랍된 아이템들을 리프레쉬 해줌
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            //아이템 이미지변경
            transform.GetChild(i).GetComponentsInChildren<Image>()[1].sprite = Inventory.Container[i].item.itemImage;
            //아이템 수량 변경
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
    //선택팝업창 받았을때
    public void OnCursorSelect(InputValue value)
    {
        CursorSelect();
    }

    //선택 팝업창 띄우기
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

    //커서 움직임시 커서의 위치정보 표현
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


    //선택한 슬롯 강조
    public void ItemHighlight()
    {
        Outline[] slots = transform.GetComponentsInChildren<Outline>();
        foreach (Outline slot in slots)
        {
            slot.enabled = false;
        }
        slots[dataOrder].enabled = true;
    }

    // esc를 누를경우 선택 팝업창 종료
    public void OnCursorCancel(InputValue value)
    {
        OnSelectUI = false;
        GameManager.UI.CloseSelectUI();
    }

    public void CursorMove()
    {

    }
    //커서의 움직임 구현
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