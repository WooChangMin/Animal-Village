using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private Canvas UICanvas;
    
    private Canvas InventoryCanvas;

    public Canvas SelectUI;

    //private Vector3 SelectUiOffset = new Vector3(150,-150,0);

    private Canvas DescriptUI;


    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.SetParent(transform);

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

        /*
                DescriptUI = GameManager.Resource.Instantiate<Canvas>("UI/DescriptUI");
                DescriptUI.gameObject.name = "DescriptUI";
                DescriptUI.sortingOrder = 64;
                DescriptUI.gameObject.SetActive(false);
                DescriptUI.transform.SetParent(UICanvas.transform);*/
    }
    public void OpenInventoryUI()
    {
        InventoryCanvas.gameObject.SetActive(true);
    }

    public void CloseInventoryUI()
    {
        InventoryCanvas.gameObject.SetActive(false);
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

    public void OpenDiscriptUI()
    {
    }
    public void InitSelectUI()
    {
        SelectUI.gameObject.SetActive(true);
        SelectUI.transform.GetChild(0).gameObject.SetActive(false);
        SelectUI.transform.GetChild(1).gameObject.SetActive(false);
        SelectUI.transform.GetChild(2).gameObject.SetActive(false);
    }

    /*public void ChangeImageSlot(Sprite _sprite, int i)
    {
        //GameObject.Find("Slot"+i).GetComponentInChildren<Image>().sprite = _sprite;
        //GameObject.Find($"Slot{i}").GetComponentInChildren<CanvasRenderer>().cullTransparentMesh = false;
        GameObject.Find("Slot1").GetComponentInChildren<CanvasRenderer>().cullTransparentMesh = false;
        //slotUI.ChangeImage(_sprite);
    }*/
}