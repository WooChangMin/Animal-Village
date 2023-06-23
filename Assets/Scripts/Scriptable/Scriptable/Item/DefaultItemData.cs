using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Object", menuName = "Data/ItemData/Default Object")]
public class DefaultItemData : ItemData
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}