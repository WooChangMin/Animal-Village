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

        buttons["EquipButton"].onClick.AddListener(() => { Debug.Log("������"); });
        buttons["DumpEquipButton"].onClick.AddListener(() => { Debug.Log("���ȴٵ���"); });
    }
}
