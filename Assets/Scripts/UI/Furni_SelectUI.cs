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

        buttons["ArrangeButton"].onClick.AddListener(Test);
        buttons["DumpFurniButton"].onClick.AddListener(Test1);
    }

    private void OnDisable()
    {

        buttons["ArrangeButton"].onClick.RemoveListener(Test);
        buttons["DumpFurniButton"].onClick.RemoveListener(Test1);
    }

    private void Test()
    {
        Debug.Log("가구배치하기~");
    }

    private void Test1()
    {
        Debug.Log("가구버려버리기~");
    }
}
