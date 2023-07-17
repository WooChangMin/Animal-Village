using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(FallRoutine());
    }

    IEnumerator FallRoutine()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GameManager.Pool.Get<GameObject>(apple, transform.position, transform.rotation);
        yield return null;
    }
    /*public void Fall()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GameManager.Pool.Get<GameObject>(apple, transform.position, transform.rotation);
    }*/
}