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
        base.Actions(a);// �θ� Ŭ������ �⺻ ���� ����

        // �ڽ� Ŭ�������� �߰����� ������ �ۼ�
        // �ʿ信 ���� �θ� Ŭ������ ������ ������
        if (a == 0)
        {
            Debug.Log("������ġ�ϱ�~");
        }
        else
        {
            Debug.Log("��������������~");
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
    //    Debug.Log("������ġ�ϱ�~");
    //}
    //
    //private void Test1()
    //{
    //    Debug.Log("��������������~");
    //}
}
