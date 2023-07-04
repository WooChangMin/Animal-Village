using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , IInteractable
{
    public void Interact()
    {
        SceneChange();
    }

    private void SceneChange()
    {
        GameManager.Scene.LoadScene("ShopScene");
    }
}
