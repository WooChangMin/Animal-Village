using Mono.CompilerServices.SymbolWriter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject StartUI;

    public GameObject GameUI;

    public EventSystem eventSystem;

    private Canvas UICanvas;
    
    private GameObject InventoryUI;

    public Canvas SelectUI;

    public Canvas loadingUI;

    public Canvas CoinUI;

    private Canvas ConversationUI;

    public Canvas windowCanvas;
    private Canvas popUpCanvas;

    public Stack<PopUpUI> popUpStack;

    

    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.SetParent(transform);

        UICanvas = GameManager.Resource.Instantiate<Canvas>("UI/UICanvas");
        UICanvas.gameObject.name = "UICanvas";

        popUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popUpCanvas.gameObject.name = "PopUpCanvas";
        popUpCanvas.sortingOrder = 100;
        popUpStack = new Stack<PopUpUI>();

        windowCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        windowCanvas.gameObject.name = "WindowCanvas";
        windowCanvas.sortingOrder = 10;

        /*
                loadingUI = GameManager.Resource.Instantiate<Canvas>("UI/LoadingUI");
                loadingUI.gameObject.name = "LoadingUI";
                loadingUI.sortingOrder = 32;
                loadingUI.transform.SetParent(transform);
                loadingUI.gameObject.SetActive(false);

                InventoryCanvas = GameManager.Resource.Instantiate<Canvas>("UI/InventoryCanvas");
                InventoryCanvas.gameObject.name = "InventoryCanvas";
                InventoryCanvas.sortingOrder = 32;
                InventoryCanvas.gameObject.SetActive(false);
                InventoryCanvas.transform.SetParent(transform);


                SelectUI = GameManager.Resource.Instantiate<Canvas>("UI/SelectUI");
                SelectUI.gameObject.name = "SelectUI";
                SelectUI.sortingOrder = 32;
                SelectUI.gameObject.SetActive(false);
                SelectUI.transform.SetParent(transform);*/
        /*
        DescriptUI = GameManager.Resource.Instantiate<Canvas>("UI/DescriptUI");
        DescriptUI.gameObject.name = "DescriptUI";
        DescriptUI.sortingOrder = 64;
        DescriptUI.gameObject.SetActive(false);
        DescriptUI.transform.SetParent(UICanvas.transform);*/
    }

    public void LoadMapUI()
    {
        UICanvas = GameManager.Resource.Instantiate<Canvas>("UI/UICanvas");
        UICanvas.gameObject.name = "UICanvas";

        InventoryUI = GameManager.Resource.Instantiate<GameObject>("UI/InventoryUI_proto");
        InventoryUI.gameObject.name = "InventoryUI";
        InventoryUI.transform.position = new Vector3(960, 540, 0);
        InventoryUI.gameObject.SetActive(false);
        InventoryUI.transform.SetParent(UICanvas.transform);

        SelectUI = GameManager.Resource.Instantiate<Canvas>("UI/SelectUI");
        SelectUI.gameObject.name = "SelectUI";
        SelectUI.sortingOrder = 32;
        SelectUI.gameObject.SetActive(false);
        SelectUI.transform.SetParent(UICanvas.transform);
    }

    public void SetFocusUI(GameObject focusUI)
    {
        eventSystem.SetSelectedGameObject(focusUI);
    }
    public void LoadShopUI()
    {
        CoinUI = GameManager.Resource.Instantiate<Canvas>("UI/CoinUI");
        CoinUI.gameObject.name = "CoinUI";
        CoinUI.sortingOrder = 16;
        CoinUI.gameObject.SetActive(true);
        CoinUI.transform.SetParent(UICanvas.transform);

        ConversationUI = GameManager.Resource.Instantiate<Canvas>("UI/NpcConversationUI");
        ConversationUI.gameObject.name = "ConversationUI";
        ConversationUI.sortingOrder = 16;
        ConversationUI.gameObject.SetActive(false);
        ConversationUI.transform.SetParent(UICanvas.transform);

/*
        OptionUI = GameManager.Resource.Instantiate<Canvas>("UI/OptionUI");
        OptionUI.gameObject.name = "OptionUI";
        OptionUI.sortingOrder = 32;
        OptionUI.gameObject.SetActive(false);
        OptionUI.transform.SetParent(UICanvas.transform);

        ConversationUI.sortingOrder = 16;
        ConversationUI = GameManager.Resource.Instantiate<Canvas>("UI/NpcConversationUI");
        ConversationUI.gameObject.name = "ConversationUI";
        ConversationUI.gameObject.SetActive(false);
        ConversationUI.transform.SetParent(UICanvas.transform);
*/

    }
    public void OpenInventoryUI()
    {
        InventoryUI.gameObject.SetActive(true);
    }

    public void CloseInventoryUI()
    {
        InventoryUI.gameObject.SetActive(false);
    }
    public T ShowWindowUI<T>(T windowUI) where T : WindowUI
    {
        T ui = GameManager.Pool.GetUI(windowUI);
        ui.transform.SetParent(windowCanvas.transform, false);
        return ui;
    }

    public T ShowWindowUI<T>(string path) where T : WindowUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowWindowUI(ui);
    }
    public void CloseWindowUI<T>(T windowUI) where T : WindowUI
    {
        GameManager.Pool.ReleaseUI(windowUI.gameObject);
    }
    public void OpenSelectUI(ItemType type)
    {
        InitSelectUI();
            
        switch (type)
        {            
            case ItemType.Default:
                SelectUI.transform.GetChild((int)type).gameObject.SetActive(true);
                break;
            case ItemType.Equipment:
                SelectUI.transform.GetChild((int)type).gameObject.SetActive(true);
                break;
            case ItemType.Furniture:
                SelectUI.transform.GetChild((int)type).gameObject.SetActive(true);
                break;
        }
    }
    public void CloseSelectUI()
    {
        SelectUI.gameObject.SetActive(false);
    }
/*
    public void OpenDiscriptUI()
    {
    }*/
    public void InitSelectUI()
    {
        SelectUI.gameObject.SetActive(true);
        SelectUI.transform.GetChild(0).gameObject.SetActive(false);
        SelectUI.transform.GetChild(1).gameObject.SetActive(false);
        SelectUI.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void OpenConversationUI()
    {
        ConversationUI.gameObject.SetActive(true);
        //ConversationUI.GetComponentInChildren<TMP_Text>().text = dialogue;
    }

    public void CloseConversationUI()
    {
        ConversationUI.gameObject.SetActive(false);
    }

    public void OpenOptionUI()
    {

       //GameObject obj = GameManager.UI.OptionUI.gameObject;
       //obj.SetActive(true);
        
        //Outline[] lineContainer = obj.GetComponentsInChildren<Outline>();
       // for(int i = 0;  i< lineContainer.Count() ;  i++)
    }

    public void CloseOptionUI()
    {
        ConversationUI.GetComponentInChildren<OptionUI>().gameObject.SetActive(false);
    }

    public T ShowPopUpUI<T>(T popUpUI) where T : PopUpUI
    {
        if (popUpStack.Count > 0)
        {
            PopUpUI prevUI = popUpStack.Peek();
            //prevUI.gameObject.SetActive(false);
        }

        T ui = GameManager.Pool.GetUI<T>(popUpUI);
        ui.transform.SetParent(UICanvas.transform, false);
        popUpStack.Push(ui);

        Time.timeScale = 0f;
        return ui;
    }
    public T ShowPopUpUI<T>(string path) where T : PopUpUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowPopUpUI(ui);
    }

    public void ClosePopUpUI()
    {
        PopUpUI ui = popUpStack.Pop();
        GameManager.Pool.ReleaseUI(ui.gameObject);
        if (popUpStack.Count > 0)
        {
            PopUpUI curUI = popUpStack.Peek();
            curUI.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}