using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    public void OnEnable()
    {
        InitPosition();

    }


    public void InitPosition()
    {
        transform.GetChild(0).position = new Vector3(2000f, 2000f, 0);
        transform.GetChild(1).position = new Vector3(2000f, 2000f, 0);
        transform.GetChild(2).position = new Vector3(2000f, 2000f, 0);
    }
    public void UIPosition(ItemType type, int order)
    {
        switch (type)   
        {
            case ItemType.Furniture:
                InitPosition();
                transform.GetChild(2).position = new Vector3(1400f + 130 * (order % 4), 650f - 130 * (order / 4), 0);
                break;
            case ItemType.Equipment:
                InitPosition();
                transform.GetChild(1).position = new Vector3(1400f + 130 * (order % 4), 650f - 130 * (order / 4), 0);
                break;
            case ItemType.Default:
                InitPosition();
                transform.GetChild(0).position = new Vector3(1400f + 130 * (order % 4), 650f - 130 * (order / 4), 0);
                break;
        }
    }
}
