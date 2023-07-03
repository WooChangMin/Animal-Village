using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    private Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    public void FadeIn()    
    {
        animator.SetTrigger("FadeIn");
        LoadingUIOff();

    }

    public void FadeOut()
    {
        LoadingUIOn();
        animator.SetTrigger("FadeOut");
    }

    public void LoadingUIOff()
    {
        gameObject.SetActive(false);
    }

    public void LoadingUIOn()
    {
        gameObject.SetActive(true);
    }

}
    