using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "Inventory", menuName = "Data/Inven0tory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public GameObject InventoryUI;
    public UnityAction OnInventoryChanged;
        
    public void AddItem(ItemData _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                
                if(_item.overlapCount <= Container[i].amount)
                {
                    continue;
                }
                
                if (_item.overlapCount > Container[i].amount)
                {
                    hasItem = true;
                    Container[i].AddAmount(_amount);
                    OnInventoryChanged?.Invoke();
                    break;
                }
                else if (Container.Count >= 16)
                {
                    hasItem = true;
                    //안된다는팝업
                    break;
                }
                else
                {
                    hasItem = true;
                    //GameManager.UI.ChangeImageSlot(_item.itemImage, Container.Count);
                    Container.Add(new InventorySlot(_item, _amount));
                    OnInventoryChanged?.Invoke();
                    break;
                }
            }
        }
        if (!hasItem)
        {
            if(Container.Count < 16)
            {
                //GameManager.UI.ChangeImageSlot(_item.itemImage, Container.Count);
                Container.Add(new InventorySlot(_item, _amount));
                OnInventoryChanged?.Invoke();
            }            
            else
            {
                //안된다는 팝업
            }                
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
