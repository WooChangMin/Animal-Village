using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventoryUI : BaseUI
{
    public InventoryObject Inventory;

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
        Transform[] myChildren = this.GetComponentsInChildren<Transform>();

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
    public void AddItem()
    {

    }

    public void SwapItem()
    {

    }

    private void DropItem()
    {

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