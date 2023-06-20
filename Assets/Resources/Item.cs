using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Equipment, QuestItem, Ingredient, Etc, Size }
public class Item
{
    public ItemType itemType;
    protected string itemName;
    protected Sprite itemImage;
}