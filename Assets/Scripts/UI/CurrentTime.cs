using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTime : MonoBehaviour
{
    [SerializeField] Text time1, time2;

    public void Update()
    {

        time1.text = DateTime.Now.ToString("Y / M / D");
        time2.text = DateTime.Now.ToString("HH : MM : SS");

    }
}
