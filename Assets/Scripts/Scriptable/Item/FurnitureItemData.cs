using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Furniture Object", menuName = "Data/ItemData/Furniture Object")]
public class FurnitureItemData : ItemData
{
    public int gorgeousPoint;   
    public void Awake()
    {
        type = ItemType.Furniture;
    }
}
