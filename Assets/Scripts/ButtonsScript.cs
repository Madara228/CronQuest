using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonsScript : MonoBehaviour
{
    public QuestScripts questScripts;
    public TextMeshProUGUI m_text_1;
    public TextMeshProUGUI m_text_2;
    public TextMeshProUGUI m_text_3;
    public TextMeshProUGUI m_text_4;

    private void Start()
    {
        //Debug.Log(m_text.gameObject.name);
        
    }
    public void GetText()
    {
        if (m_text_1.text != questScripts.rightAnswer) { 
            Debug.Log(questScripts.rightAnswer);
            Debug.Log("Не то");
            questScripts.voidWriteText("Не то!");
        }
        else
        {
            questScripts.voidWriteText("В точку!");
        }
    }
    public void GetText2()
    {
        if (m_text_2.text != questScripts.rightAnswer)
        {
            questScripts.voidWriteText("Не то!");
        }
        else
        {
            questScripts.voidWriteText("В точку!");
        }
    }
    public void GetText3()
    {
        if (m_text_3.text != questScripts.rightAnswer)
        {
            questScripts.voidWriteText("Не то!");
        }
        else
        {
            questScripts.voidWriteText("В точку!");
        }
    }
    public void GetText4()
    {
        if (m_text_4.text != questScripts.rightAnswer)
        {
            questScripts.voidWriteText("Не то!");
        }
        else
        {
            questScripts.voidWriteText("В точку!");
        }
    }
}
