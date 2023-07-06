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
        if (Input.GetKeyDown(KeyCode.Space))
        {                 
            if (!option.gameObject.activeSelf)
            {
                ChangeDialogue();
            }
        }        
    }

    private void OnEnable()
    {
        gameObject.GetComponentInChildren<OptionUI>().OnChangeDialogue += DialogueSequence;
        ChangeDialogue();
        
        //FindObjectOfType<OptionUI>().OnChangeDialogue += ChangeDialogue;

    }
    private void OnDisable()
    {
        transform.GetComponentInChildren<OptionUI>().OnChangeDialogue -= DialogueSequence;
        //FindObjectOfType<OptionUI>().OnChangeDialogue -= ChangeDialogue;
    }

    private void ChangeDialogue()
    {
        curDialogue.text = dialogue.container[dialogueOrder].descript.ToString();
    }
    private void DialogueSequence(int order)
    {
        switch (order)
        {
            case 0:
                dialogueOrder = 1;
                ChangeDialogue();
                GameManager.UI.OpenShopUI();

                break;


        }

        if(order <= 1)
            dialogueOrder = order + 1;
        else
            dialogueOrder = 3;
        ChangeDialogue();
    }
}
