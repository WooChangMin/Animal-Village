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

public class InventoryUI : BaseUI, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public InventoryObject Inventory;
    public int dataOrder;
    private Vector3 moveDir;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {        
        Inventory.OnInventoryChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChanged -= Refresh;
    }

    public void Refresh()
    {
        //trnasform을 가지는 모든 자식오브젝트 가져옴
        RectTransform[] myChildren = this.GetComponentsInChildren<RectTransform>();

        // 마우스 커서의 위치 이동
        //myChildren[51].anchoredPosition = new Vector3(350, 130, 0);

        myChildren[51].anchoredPosition = new Vector3(350 + (130 * (dataOrder%4)), 130 - (130 * (dataOrder/4)), 0);
        
        //인벤토리를 열때마다 드랍된 아이템들을 리프레쉬 해줌

        for (int i = 0; i < Inventory.Container.Count; i++)
        {            
            
            myChildren[3*i+3].GetComponentInChildren<Image>().sprite = Inventory.Container[i].item.itemImage;
            myChildren[3*i+4].GetComponentInChildren<Text>().text = Inventory.Container[i].amount.ToString();
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


    public void SwapItem()
    {

    }

    private void DropItem()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemExplain();
    }

    private void ItemExplain()
    {

    }
    public void OnCursorSelect(InputValue value)
    {
        GameManager.UI.OpenSelectUI(Inventory.Container[dataOrder].item.type, dataOrder);
    }

    public void OnCursorMove(InputValue value)
    {
        if (value.Get<Vector2>().x > 0)
        {
            Debug.Log("x축양");
            if (dataOrder % 4 ==3  )
            {
                dataOrder -= 3;
            }
            else
            {
                dataOrder += 1 ;
            }
            Refresh();
            Debug.Log(dataOrder);
        }
        
        if(value.Get<Vector2>().x < 0)
        {
            Debug.Log("x축음");
            if (dataOrder % 4 == 0)
            {
                dataOrder += 3;
            }
            else
            {
                dataOrder -= 1;
            }

            Refresh();

            Debug.Log(dataOrder);
        }
        
        if (value.Get<Vector2>().y > 0)
        {
            Debug.Log("y축양");
            if (dataOrder / 4 == 0)
            {
                dataOrder += 12;
            }
            else
            {
                dataOrder -= 4;
            }
            Refresh();

            Debug.Log(dataOrder);
        }
        
        if(value.Get<Vector2>().y < 0)
        {
            Debug.Log("y축음");
            if (dataOrder / 4 == 3)
            {
                dataOrder -= 12;
            }
            else
            {
                dataOrder += 4;
            }

            Refresh();

            Debug.Log(dataOrder);
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }


    /*[System.Serializable]
    public class InventorySlot
    {
        public ItemData item;
        public int amount;
        public InventorySlot(ItemData _item, int _amount)
        {
            item = _item;
            amount = _amount;
        }

        public void AddAmount(int value)
        {
            amount += value;
        }
    }*/
}