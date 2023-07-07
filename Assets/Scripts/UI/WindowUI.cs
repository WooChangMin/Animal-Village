using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUI : BaseUI
{

    public override void CloseUI()
    {
        base.CloseUI();

        GameManager.UI.CloseWindowUI(this);
    }
}
