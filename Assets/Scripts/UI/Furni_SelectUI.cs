using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furni_SelectUI : BaseUI
{
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
            Debug.Log("가구배치하기~");
        }
        else
        {
            Debug.Log("가구버려버리기~");
        }
    }
    //private void OnEnable()
    //{
    //
    //    buttons["ArrangeButton"].onClick.AddListener(Test);
    //    buttons["DumpFurniButton"].onClick.AddListener(Test1);
    //}
    //
    //private void OnDisable()
    //{
    //
    //    buttons["ArrangeButton"].onClick.RemoveListener(Test);
    //    buttons["DumpFurniButton"].onClick.RemoveListener(Test1);
    //}
    //
    //private void Test()
    //{
    //    Debug.Log("가구배치하기~");
    //}
    //
    //private void Test1()
    //{
    //    Debug.Log("가구버려버리기~");
    //}
}
