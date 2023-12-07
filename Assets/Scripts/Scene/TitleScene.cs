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
        
    }
    protected override IEnumerator LoadingRoutine()
    {
        progress = 0;


        yield return null;
    }
    /*private void ChangeMenu()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            GameManager.UI.
    }

    if(Input.GetKeyDown(KeyCode.Space))
            GameManager.Scene.LoadScene("MapScene");

*/
        
    private void OnDestroy()
    {
        
    }   
}
