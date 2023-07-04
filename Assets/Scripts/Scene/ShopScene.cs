using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScene : BaseScene
{
    private void Awake()
    {
        Debug.Log("�ʾ� �ε�");
    }
    protected override IEnumerator LoadingRoutine()
    {
        GameManager.UI.LoadMapUI();


        GameManager.UI.LoadShopUI();


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
        Debug.Log("ShopScene Load");
        yield return null;
    }
    private void OnDestroy()
    {
        Debug.Log("MapScene Release");
    }
}
