using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QuestScripts : MonoBehaviour
{
   
    public Button[] buttons;
    public string rightAnswer;
    #region private_vars
    [SerializeField] private Transform[] pos;
    [SerializeField] string Quest_txt;
    [SerializeField] TextMeshProUGUI Quest_text;
    [SerializeField] string answer1;
    [SerializeField] string answer2;
    [SerializeField] string answer3;
    #endregion
    void Start()
    {
        
        buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = answer1;
        buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = answer2;
        buttons[2].GetComponentInChildren<TextMeshProUGUI>().text = answer3;
        buttons[3].GetComponentInChildren<TextMeshProUGUI>().text = rightAnswer;

        ShuffleButtons(buttons);

    }

    void Update()
    {
        
    }

    private void ShuffleButtons(Button[] btns)
    {
        for (var i = 0; i < pos.Length; i++)
        {
            var j = Random.Range(0, pos.Length);
            var tmp = pos[i].position;
            pos[i].position = pos[j].position;
            pos[j].position = tmp;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(writeText(Quest_txt));
        }
    }

    private IEnumerator writeText(string strTxt)
    {
        string output = "";
        foreach (char c in strTxt)
        {
            output += c;
            Quest_text.text = output;
            yield return new WaitForSeconds(0.03f);
        }
    }
    public void voidWriteText(string text)
    {
        StartCoroutine(writeText(text));
    }
    
}
