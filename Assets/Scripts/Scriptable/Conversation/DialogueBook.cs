using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using UnityEngine;

[CreateAssetMenu (fileName = "DialogueBook", menuName = "Data/Dialogue")]
public class DialogueBook : ScriptableObject
{
    public List<Descripts> container = new List<Descripts>();   
}