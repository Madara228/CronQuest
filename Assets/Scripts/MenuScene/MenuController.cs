using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;
public class MenuController : MonoBehaviour
{
    public static JSONNode node;
    public int sceneCount;
    public Button[] allObjects;
    void Start()
    {
        //allObjects = UnityEngine.Object.FindObjectsOfType<Button>();
        CheckScene();
        for (int i = 0; i < sceneCount; i++)
        {
            allObjects[i].interactable = true;
        }
    }
    void CheckScene()
    {
        var jsonTextFile = Resources.Load<TextAsset>("document");
        node = JSON.Parse(jsonTextFile.text);

        sceneCount = node["count"];
    }
}
