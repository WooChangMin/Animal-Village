using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Default_SelectUI : BaseUI
{
    public UnityAction OnItemDrop;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        buttons["ObserveButton"].onClick.AddListener(Test);
        buttons["DumpButton"].onClick.AddListener(Test1);
    }

    private void OnDisable()
    {

        buttons["ObserveButton"].onClick.RemoveListener(Test);
        buttons["DumpButton"].onClick.RemoveListener(Test1);
    }

    private void Test()
    {
        Debug.Log("АќТћСп");
    }

    private void Test1()
    {
        //OnItemDrop.Invoke();
    }
}