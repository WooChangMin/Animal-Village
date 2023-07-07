using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopUI : PopUpUI
{
    int selectData=0;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectData < 7)
            {
                selectData++;
                Debug.Log(selectData);
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (selectData >0)
            {
                selectData--;
            }
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}