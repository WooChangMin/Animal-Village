using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Sprite sprite;
    public Text text;

    public Slot(Sprite _sprite, Text _text)
    {
        sprite = _sprite;
        text = _text;
    }
   /* public void OnEnable()
    {
        GetComponentInChildren<Image>() = sprite;
        GetComponentInChildren<Text>() = text;
    }*/
}
