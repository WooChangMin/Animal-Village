using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    private LoadingUI loadingUI;

    private BaseScene curScene;
    public BaseScene CurScene
    {
        get
        {
            if(curScene == null)
                curScene = GameObject.FindObjectOfType<BaseScene>();
            
            return curScene;
        }
    }

    private void Awake()
    {
        loadingUI = GameManager.Resource.Instantiate<LoadingUI>("UI/LoadingUI");
        loadingUI.gameObject.name = "LoadingUI";
        loadingUI.gameObject.SetActive(false);
        loadingUI.transform.SetParent(transform);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        loadingUI.FadeOut();
        yield return new WaitForSecondsRealtime(3f);
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        while (!oper.isDone)
        {
            //loadingUI.SetProgress(Mathf.Lerp(0.0f, 0.5f, oper.progress));
            yield return null;
        }

        if (CurScene != null)
        {
            CurScene.LoadAsync();
            while (CurScene.progress < 1f)
            {
                //loadingUI.SetProgress(Mathf.Lerp(0.5f, 1f, CurScene.progress));
                yield return null;
            }
        }
        yield return new WaitForSecondsRealtime(2f);

        loadingUI.FadeIn();
    }
}
    