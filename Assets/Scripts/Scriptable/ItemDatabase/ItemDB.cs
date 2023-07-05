using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDB", menuName = "Data/ItemDB")]
public class ItemDB : ScriptableObject
{
    public List<GameObject> items = new List<GameObject>();
}