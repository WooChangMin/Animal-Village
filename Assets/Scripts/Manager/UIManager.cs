using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    private EventSystem eventSystem;

    private Canvas UICanvas;
    
    private Canvas InventoryCanvas;

    private Canvas SelectUI;

    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.SetParent(transform);

        UICanvas = GameManager.Resource.Instantiate<Canvas>("UI/UICanvas");
        UICanvas.gameObject.name = "UICanvas";
        
        InventoryCanvas = GameManager.Resource.Instantiate<Canvas>("UI/InventoryUI");
        InventoryCanvas.gameObject.name = "InventoryCanvas";
        InventoryCanvas.sortingOrder = 32;
        InventoryCanvas.gameObject.SetActive(false);
        InventoryCanvas.transform.SetParent(UICanvas.transform);


        SelectUI = GameManager.Resource.Instantiate<Canvas>("UI/SelectUI");
        SelectUI.gameObject.name = "SelectUI";
        SelectUI.sortingOrder = 64;
        SelectUI.gameObject.SetActive(false);
        SelectUI.transform.SetParent(UICanvas.transform);
    }

    public void OpenInventoryUI()
    {
        InventoryCanvas.gameObject.SetActive(true);
    }

    public void CloseInventoryUI()
    {
        InventoryCanvas.gameObject.SetActive(false);
    }

    public void OpenSelectUI(ItemType type, int order)
    {
        switch (type)
        {
            case ItemType.Furniture:
                GameObject gameObj = GameObject.Find("Furni_SelectUI");
                gameObj.SetActive(true);
                gameObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(350 + (130 * (order % 4)), 130 - (130 * (order / 4)), 0);
                break;
            case ItemType.Equipment:
                GameObject gameObj1 = GameObject.Find("EquipUI");
                gameObj1.SetActive(true);
                gameObj1.GetComponent<RectTransform>().anchoredPosition = new Vector3(350 + (130 * (order % 4)), 130 - (130 * (order / 4)), 0);
                break;
            case ItemType.Default:
                GameObject gameObj2 = GameObject.Find("DefaultUI");
                gameObj2.SetActive(true);
                gameObj2.GetComponent<RectTransform>().anchoredPosition = new Vector3(350 + (130 * (order % 4)), 130 - (130 * (order / 4)), 0);
                break;
        }
    }

    public void CloseSelectUI()
    {

    }
    
    /*public void ChangeImageSlot(Sprite _sprite, int i)
    {
        //GameObject.Find("Slot"+i).GetComponentInChildren<Image>().sprite = _sprite;
        //GameObject.Find($"Slot{i}").GetComponentInChildren<CanvasRenderer>().cullTransparentMesh = false;
        GameObject.Find("Slot1").GetComponentInChildren<CanvasRenderer>().cullTransparentMesh = false;
        //slotUI.ChangeImage(_sprite);
    }*/
}