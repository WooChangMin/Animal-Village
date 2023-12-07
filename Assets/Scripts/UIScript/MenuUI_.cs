using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI_ : MonoBehaviour
{
    [SerializeField] private GameObject MenuCanvas;
    [SerializeField] private GameObject SaveCanvas;

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject saveButton_1;

    private void Start()
    {
        MenuCanvas.SetActive(true);
        SaveCanvas.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.UI.SetFocusUI(startButton);
    }
    public void StartGame()
    {
        GameManager.Scene.LoadScene("MapScene");
    }

    public void SaveMenu()
    {
        MenuCanvas.SetActive(false);
        SaveCanvas.SetActive(true);
        GameManager.UI.SetFocusUI(saveButton_1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Save1()
    {

    }
    public void Save2()
    {

    }
    public void BackMenu()
    {
        MenuCanvas.SetActive(true);
        SaveCanvas.SetActive(false);

        GameManager.UI.SetFocusUI(startButton);
    }
}
