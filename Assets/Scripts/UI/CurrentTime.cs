using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTime : BaseUI
{
    [SerializeField] Text time1, time2;

    public void Update()
    {
        time1.text = DateTime.Now.ToString("yy / MM / dd");
        time2.text = DateTime.Now.ToString("hh : mm : ss");
    }
}   