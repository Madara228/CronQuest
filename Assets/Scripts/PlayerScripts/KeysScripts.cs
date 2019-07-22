using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeysScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public string rightAnswer;
    public TMP_InputField inputField;
    public GameObject door;
    public Sprite _sprite;
    public 
    void Start()
    {
        
    }
    public void onButtonClick(string s)
    {
        s = inputField.text;
        if(s == rightAnswer)
        {
            door.GetComponent<BoxCollider2D>().isTrigger = true;
            door.GetComponent<SpriteRenderer>().sprite = _sprite;  
        }
    }
}
