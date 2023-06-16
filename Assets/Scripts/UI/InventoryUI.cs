using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : BaseUI
{
    public GameObject inventoryPanel;
    bool activeInventory = false;

    private void Start()
    {
        inventoryPanel.SetActive(activeInventory);
    }

    private void OnInventory(InputValue value)
    {
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
    }
}
