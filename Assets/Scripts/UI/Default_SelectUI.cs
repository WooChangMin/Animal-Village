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
        base.Actions(a);// �θ� Ŭ������ �⺻ ���� ����

        // �ڽ� Ŭ�������� �߰����� ������ �ۼ�
        // �ʿ信 ���� �θ� Ŭ������ ������ ������
        if (a == 0)
        {
            Debug.Log("������");
        }
        else
        {
            Debug.Log("������");
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
    //    Debug.Log("������");
    //}
    //
    //private void Test1()
    //{
    //    Debug.Log("������");
    //}
}