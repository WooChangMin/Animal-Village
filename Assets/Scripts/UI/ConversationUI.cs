using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationUI : MonoBehaviour
{
    public DialogueBook dialogue;
    private int dialogueOrder = 0;

    TMP_Text curDialogue;

    private void Awake()
    {
        curDialogue = gameObject.GetComponent<TMP_Text>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueOrder!=0)
        {
             
        }
        
    }

    private void OnEnable()
    {

        FindObjectOfType<OptionUI>().OnChangeDialogue += ChangeDialogue;

    }

    private void OnDisable()
    {
        FindObjectOfType<OptionUI>().OnChangeDialogue -= ChangeDialogue;
    }

    private void ChangeDialogue(int order)
    {
        dialogueOrder = order+1;
        curDialogue.text = dialogue.container[dialogueOrder].descript.ToString();
    }
}
