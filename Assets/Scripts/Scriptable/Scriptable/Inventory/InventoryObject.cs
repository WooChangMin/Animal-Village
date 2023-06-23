using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "Inventory", menuName = "Data/Inven0tory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public GameObject InventoryUI;
    
    public void AddItem(ItemData _item, int _amount)
    {
        bool hasItem = false;
        if(Container.Count >= 16)
        {
            //GameManager.UI.openPopUpUI();
        }

        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                hasItem = true;
                Container[i].AddAmount(_amount);
                InventoryUI.transform.Find("Slot" + i+1).GetComponentInChildren<Image>().sprite = Container[i].item.itemImage;
                break;
            }
        }
        if(!hasItem)    
        {
            Container.Add(new InventorySlot(_item, _amount));
           
        }
    }   
}

[System.Serializable]
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
}
