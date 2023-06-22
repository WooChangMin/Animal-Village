using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ItemData", menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] ItemDB[] items;

    protected ItemDB[] Item { get { return items; } }   

    [Serializable]    
    public class ItemDB
    {
        public string name;
        public string description;
        public int salePrice;
    }
    
}
