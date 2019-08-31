using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NewKeysScript : MonoBehaviour
{
    public List<KeyCode> xkeys = new List<KeyCode>();
    public string mString;
    public string rightString;
    public TextMeshProUGUI textMesh;
    bool isHere;
    public GameObject door;
    private void Start()
    {
        xkeys.Add(KeyCode.Alpha0);
        xkeys.Add(KeyCode.Alpha1);
        xkeys.Add(KeyCode.Alpha2);
        xkeys.Add(KeyCode.Alpha3);
        xkeys.Add(KeyCode.Alpha4);
        xkeys.Add(KeyCode.Alpha5);
        xkeys.Add(KeyCode.Alpha6);
        xkeys.Add(KeyCode.Alpha7);
        xkeys.Add(KeyCode.Alpha8);
        xkeys.Add(KeyCode.Alpha9);
    }

    private void Update()
    {
        if (isHere)
        {
            InpudKeys();
            
        }
        InputKeys();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isHere = false;
        }
    }
    private void InpudKeys()
    {
        foreach (KeyCode xkey in xkeys)
        {
            if (Input.GetKeyDown(xkey))
            {
                var charsToRemove = new string[] { "A", "l", "p", "h", "a" };
                mString += xkey;
                foreach (var c in charsToRemove)
                {
                    mString = mString.Replace(c, string.Empty);
                }
                textMesh.text = mString;
                Check(mString, rightString);
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            mString = mString.Remove(mString.Length - 1);
            textMesh.text = mString;
            Check(mString, rightString);
            Debug.Log(mString);
        }
    }
    private void InputKeys()
    {
        //foreach(KeyCode xKey in xkeys)
        //{
        //    if (Input.GetKey(xKey))
        //    {
        //        Debug.Log(xKey);
        //    }
        //}
        
    }

    void Check(string _mstring, string _rightString)
    {
        if(_mstring == _rightString)
        {
            Destroy(door);
        }
    }


    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("[enter]")))
        {
            Debug.Log("enter");
        }
    }
}
