using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furni_SelectUI : BaseUI
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        buttons["ArrangeButton"].onClick.AddListener(() => { Debug.Log("배치중"); });
        buttons["DumpFurniButton"].onClick.AddListener(() => { Debug.Log("버렸다가구"); });
    }
}
