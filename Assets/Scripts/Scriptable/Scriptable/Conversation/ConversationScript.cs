using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu (fileName = "ConversationScripts" , menuName = "Data/Conversation")]
public class ConversationScript : ScriptableObject
{
    public List<string> container = new List<string>();
}