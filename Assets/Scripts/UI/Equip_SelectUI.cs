using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_SelectUI : BaseUI 
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
            Debug.Log("������");
        }
        else
        {
            Debug.Log("������������~");
        }
    }

    //private void OnEnable()
    //{
    //
    //    buttons["EquipButton"].onClick.AddListener(Test);
    //    buttons["DumpEquipButton"].onClick.AddListener(Test1);
    //}
    //
    //private void OnDisable()
    //{
    //
    //    buttons["EquipButton"].onClick.RemoveListener(Test);
    //    buttons["DumpEquipButton"].onClick.RemoveListener(Test1);
    //}
    //
    //private void Test()
    //{
    //    Debug.Log("������");
    //}
    //
    //private void Test1()
    //{
    //    Debug.Log("������������~");
    //}
}
