using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tree : MonoBehaviour, IInteractable
{
    GameObject lemon;
    Vector3 randOffset;

    private void Awake()
    {
        lemon = GameManager.Resource.Load<GameObject>("Prefabs/Lemon");
    }
    public void Interact()
    {
        StartCoroutine(FallRoutine());
    }

    IEnumerator FallRoutine()
    {
        transform.GetChild(0).gameObject.SetActive(false);

        //랜덤한 위치에 생성
        for (int i = 0; i <3; i++)
        {
            int ran = Random.Range(0, 360);
            float x = Mathf.Cos(ran * Mathf.Deg2Rad) * 3f;
            float z = Mathf.Sin(ran * Mathf.Deg2Rad) * 3f;
            randOffset = new Vector3(x, 0.1f, z);

            GameManager.Pool.Get<GameObject>(lemon, transform.position + randOffset, transform.rotation);
        }
        yield return null;
    }

    /*public void Fall()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GameManager.Pool.Get<GameObject>(apple, transform.position, transform.rotation);
    }*/
}