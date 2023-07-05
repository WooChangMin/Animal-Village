using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Descripts", menuName = "Data/Descript")]
public class Descripts : ScriptableObject
{
    [TextArea(3, 10)]
    public string descript;
}
