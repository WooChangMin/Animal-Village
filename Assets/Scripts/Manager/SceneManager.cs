using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        LoadingUI loadingUI = Resources.Load<LoadingUI>("UI/LoadingUI");
        this.loadingUI = Instantiate(loadingUI);
        this.loadingUI.transform.SetParent(transform);
        this.loadingUI.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }
    
    IEnumerator LoadingRoutine(string SceneName)
    {
        //loadingUI.progress = 0f;

        loadingUI.FadeOut();
        Time.timeScale = 0f;


        //loadingUI.SetProgress(1f);
        loadingUI.FadeIn();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
    }
}
    