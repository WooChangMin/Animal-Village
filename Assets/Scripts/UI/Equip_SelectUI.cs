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

        buttons["EquipButton"].onClick.AddListener(() => { Debug.Log("ÀåÂøÁß"); });
        buttons["DumpEquipButton"].onClick.AddListener(() => { Debug.Log("¹ö·È´Ùµµ±¸"); });
    }
}
