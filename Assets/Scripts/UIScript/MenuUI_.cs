using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI_ : MonoBehaviour
{
    [SerializeField] private GameObject MenuCanvas;
    [SerializeField] private GameObject SaveCanvas;

    private void Start()
    {
        MenuCanvas.SetActive(true);
        SaveCanvas.SetActive(false);
    }
    public void StartGame()
    {
        GameManager.Scene.LoadScene("MapScene");
    }

    public void SaveMenu()
    {
        MenuCanvas.SetActive(false);
        SaveCanvas.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        MenuCanvas.SetActive(true);
        SaveCanvas.SetActive(false);

    }
}
