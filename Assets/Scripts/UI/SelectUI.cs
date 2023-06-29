using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : BaseUI
{

    protected override void Awake()
    {
        base.Awake();
        buttons["ObserveButton"].onClick.AddListener(() => { Debug.Log("°üÂûÁß"); });
        buttons["DumpButton"].onClick.AddListener(() => { Debug.Log("¹ö·È´ÙÀâÅÛ"); });


        buttons["EquipButton"].onClick.AddListener(() => { Debug.Log("ÀåÂøÁß"); });
        buttons["DumpEquipButton"].onClick.AddListener(() => { Debug.Log("¹ö·È´Ùµµ±¸"); });


        buttons["ArrangeButton"].onClick.AddListener(() => { Debug.Log("¹èÄ¡Áß"); });
        buttons["DumpFurniButton"].onClick.AddListener(() => { Debug.Log("¹ö·È´Ù°¡±¸"); });
    }

}
