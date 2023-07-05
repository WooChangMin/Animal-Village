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

    protected override IEnumerator LoadingRoutine()
    {
        progress = 0;


        yield return null;
    }
        
    private void OnDestroy()
    {
        
    }
    public void GameStart()
    {
        GameManager.Scene.LoadScene("MapScene");
    }

    public void OnGameStart()
    {
        GameStart();
    }
}
