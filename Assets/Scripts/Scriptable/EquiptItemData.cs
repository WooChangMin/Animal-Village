using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName = "EquipmentItemData", menuName = "Data/ItemData/EquiptmentItemData")]
public class EquiptItemData : ItemData
{

    /*public string Name { get { return this.name; } }
    public string Info { get { return this.description; } }

    public int Price { get { return this.salePrice; } }     
*/  
    [SerializeField] public int Durability;

}
