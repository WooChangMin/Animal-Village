using System.Collections;
using System.Collections.Generic;f
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    GameObject apple;

    private void Awake()
    {
        apple = GameManager.Resource.Load<GameObject>("Prefabs/Apple");
    }
    public void Interact()
    {
        Fall();
    }

    public void Fall()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GameManager.Pool.Get<GameObject>(apple, transform.position, transform.rotation);
    }

}