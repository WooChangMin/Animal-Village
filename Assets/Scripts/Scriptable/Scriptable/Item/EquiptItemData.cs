using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName = "EquipmentItemData", menuName = "Data/ItemData/EquiptmentItemData")]
public class EquiptItemData : ItemData
{
    private void Awake()
    {
        type = ItemType.Equipment;
    }
    public int Durability;

    public int damage;
}
