using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class ConversationUI : MonoBehaviour
{
    public DialogueBook dialogue;
    private int dialogueOrder = 0;
    OptionUI option;
    Image image;
    
    TMP_Text curDialogue;

    private void Awake()
    {
        curDialogue = gameObject.GetComponentInChildren<TMP_Text>();
        option = gameObject.GetComponentInChildren<OptionUI>(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueOrder = 0;
            CloseAll();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!option.gameObject.activeSelf)
            {
                DialogueSequence(dialogueOrder);
                if (!(dialogueOrder == 4))
                    ChangeDialogue();
                else
                {
                    CloseAll();
                }
            }
        }
        
    }

    private void OnEnable()
    {
        dialogueOrder = 0;
        ChangeDialogue();
        gameObject.GetComponentInChildren<OptionUI>().OnChangeDialogue += DialogueSequence;
        FindObjectOfType<PlayerControll>().enabled = false;
        //FindObjectOfType<OptionUI>().OnChangeDialogue += ChangeDialogue;

    }
    private void OnDisable()
    {
        gameObject.GetComponentInChildren<OptionUI>().OnChangeDialogue -= DialogueSequence;
        FindObjectOfType<PlayerControll>().enabled = true;
        //FindObjectOfType<OptionUI>().OnChangeDialogue -= ChangeDialogue;
    }

    private void ChangeDialogue()
    {
        curDialogue.text = dialogue.container[dialogueOrder].descript.ToString();
    }
    private void DialogueSequence(int order)
    {
        if (dialogueOrder == 0)
        {
            switch (order)
            {
                case 0:
                    dialogueOrder = 1;
                    ChangeDialogue();

                    //GameManager.UI.ShowPopUpUI<PopUpUI>("UI/ShopUI");
                    break;
                case 1:
                    dialogueOrder = 2;
                    ChangeDialogue();
                    break;
                case 2:
                    dialogueOrder = 3;
                    ChangeDialogue();
                    break;            
            }
        }
        else if(dialogueOrder == 1)
        {
            StartCoroutine(BuySequence());
        }
        else if(dialogueOrder ==2)
        {
            StartCoroutine(SellSequence());
        }
        else
        {
            CloseAll();
        }
    }
    private IEnumerator BuySequence()
    {
        dialogueOrder = 3;
        ChangeDialogue();
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SelfClose();
                yield return StartCoroutine(BuyRoutine());

                yield break;
            }
            GameManager.UI.OpenInventoryUI();
            yield return null;
        }
    }

    private IEnumerator BuyRoutine()
    {
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/ShopUI");
        GameManager.UI.OpenInventoryUI();

        yield return null;
    }
    private IEnumerator SellSequence()
    {
        dialogueOrder = 3;
        ChangeDialogue();

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SelfClose();
                yield return StartCoroutine(SellRoutine());
            }
            GameManager.UI.OpenInventoryUI();
            yield return null;
        }
    }
    private IEnumerator SellRoutine()
    {

        yield return null;
    }
    private void CloseAll()
    {
        GameManager.UI.CloseSelectUI();

        GameManager.UI.CloseInventoryUI();

        
        if (GameManager.UI.popUpStack.Count > 0)
        {   
            GameManager.UI.ClosePopUpUI();
        }
        SelfClose();
    }

    // 자살하는 코드
    private void SelfClose()
    {
        option.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
