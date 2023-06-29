using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : BaseUI
{

    protected override void Awake()
    {
        base.Awake();
        buttons["ObserveButton"].onClick.AddListener(() => { Debug.Log("������"); });
        buttons["DumpButton"].onClick.AddListener(() => { Debug.Log("���ȴ�����"); });


        buttons["EquipButton"].onClick.AddListener(() => { Debug.Log("������"); });
        buttons["DumpEquipButton"].onClick.AddListener(() => { Debug.Log("���ȴٵ���"); });


        buttons["ArrangeButton"].onClick.AddListener(() => { Debug.Log("��ġ��"); });
        buttons["DumpFurniButton"].onClick.AddListener(() => { Debug.Log("���ȴٰ���"); });
    }

}
