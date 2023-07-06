using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleScene : BaseScene
{
    private void Awake()
    {
        Debug.Log("Title Scene Alive");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            GameManager.Scene.LoadScene("MapScene");
    }
    protected override IEnumerator LoadingRoutine()
    {
        progress = 0;


        yield return null;
    }
        
    private void OnDestroy()
    {
        
    }   
}
