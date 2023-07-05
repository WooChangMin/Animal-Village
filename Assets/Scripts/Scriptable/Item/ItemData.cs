using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Default,
    Equipment,
    Furniture
}
[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemname;
    public GameObject prefab;
    public Sprite itemImage;
    public ItemType type;
    public int salePrice;
    public int overlapCount;

    [TextArea(10,10)]   
    public string description;

    /*[SerializeField] ItemDB[] items;
    protected ItemDB[] Item { get { return items; } }   

    [Serializable]    
    public class ItemDB
    {
        public string name;
        public string description;
        public int salePrice;
    }*/
    
}
