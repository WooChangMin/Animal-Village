using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScene : BaseScene
{
    private void Awake()
    {
        Debug.Log("MapScene Init");
    }

    protected override IEnumerator LoadingRoutine()
    {
        GameManager.UI.LoadMapUI();

        // fake loading
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 0.2f;
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 0.4f;
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 0.6f;
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 0.8f;
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 1.0f;
    }

    private void OnDestroy()
    {
        Debug.Log("MapScene Release");
    }
}