using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    private EventSystem eventSystem;

    private Canvas UICanvas;
    
    private Canvas InventoryCanvas;

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
    }

    public void OpenInventoryUI()
    {
        InventoryCanvas.gameObject.SetActive(true);
    }

    public void CloseInventoryUI()
    {
        InventoryCanvas.gameObject.SetActive(false);
    }
    
    /*public void ChangeImageSlot(Sprite _sprite, int i)
    {
        //GameObject.Find("Slot"+i).GetComponentInChildren<Image>().sprite = _sprite;
        //GameObject.Find($"Slot{i}").GetComponentInChildren<CanvasRenderer>().cullTransparentMesh = false;
        GameObject.Find("Slot1").GetComponentInChildren<CanvasRenderer>().cullTransparentMesh = false;
        //slotUI.ChangeImage(_sprite);
    }*/
}