using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject StartUI;

    public GameObject GameUI;

    private EventSystem eventSystem;

    private Canvas UICanvas;
    
    private Canvas InventoryCanvas;

    public Canvas SelectUI;

    public Canvas loadingUI;

    public Canvas CoinUI;

    private Canvas ConversationUI;

    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.SetParent(transform);

        UICanvas = GameManager.Resource.Instantiate<Canvas>("UI/UICanvas");
        UICanvas.gameObject.name = "UICanvas";

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

        InventoryCanvas = GameManager.Resource.Instantiate<Canvas>("UI/InventoryCanvas");
        InventoryCanvas.gameObject.name = "InventoryCanvas";
        InventoryCanvas.sortingOrder = 32;
        InventoryCanvas.gameObject.SetActive(false);
        InventoryCanvas.transform.SetParent(UICanvas.transform);

        SelectUI = GameManager.Resource.Instantiate<Canvas>("UI/SelectUI");
        SelectUI.gameObject.name = "SelectUI";
        SelectUI.sortingOrder = 32;
        SelectUI.gameObject.SetActive(false);
        SelectUI.transform.SetParent(UICanvas.transform);
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
        InventoryCanvas.gameObject.SetActive(true);
    }

    public void CloseInventoryUI()
    {
        InventoryCanvas.gameObject.SetActive(false);
    }

    public void OpenShopUI()
    {

    }

    public void CloseShopUI()
    {

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
}