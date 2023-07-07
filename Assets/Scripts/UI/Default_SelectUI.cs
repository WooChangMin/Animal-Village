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

    public override void Actions(int a)
    {
        base.Actions(a);// 부모 클래스의 기본 구현 실행

        // 자식 클래스에서 추가적인 로직을 작성
        // 필요에 따라 부모 클래스의 구현을 재정의
        if (a == 0)
        {
            Debug.Log("관찰중");
        }
        else
        {
            Debug.Log("버리기");
        }
    }

    //private void OnEnable()
    //{
    //    buttons["ObserveButton"].onClick.AddListener(Test);
    //    buttons["DumpButton"].onClick.AddListener(Test1);
    //}
    //
    //private void OnDisable()
    //{
    //
    //    buttons["ObserveButton"].onClick.RemoveListener(Test);
    //    buttons["DumpButton"].onClick.RemoveListener(Test1);
    //}
    //
    //private void Test()
    //{
    //    Debug.Log("관찰중");
    //}
    //
    //private void Test1()
    //{
    //    Debug.Log("버리기");
    //}
}