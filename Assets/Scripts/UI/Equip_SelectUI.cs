using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_SelectUI : BaseUI
{
    protected override void Awake()
    {
        base.Awake();

    }

    private void OnEnable()
    {

        buttons["EquipButton"].onClick.AddListener(Test);
        buttons["DumpEquipButton"].onClick.AddListener(Test1);
    }

    private void OnDisable()
    {

        buttons["EquipButton"].onClick.RemoveListener(Test);
        buttons["DumpEquipButton"].onClick.RemoveListener(Test1);
    }

    private void Test()
    {
        Debug.Log("장착중");
    }

    private void Test1()
    {
        Debug.Log("장비버려버리기~");
    }
}
