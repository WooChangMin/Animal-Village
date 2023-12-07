using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneUI_ : MonoBehaviour
{
    [SerializeField]  private GameObject menuUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            menuUI.SetActive(true);
        }
    }
}
