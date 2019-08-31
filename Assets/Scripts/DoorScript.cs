using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform teleportPosition;
    public GameObject exitPoint;
    public void TeleportObject(GameObject player)
    {
        player.transform.position = teleportPosition.position;
        if (exitPoint.activeInHierarchy)
        {
            exitPoint.SetActive(false);
        }
        else if(!exitPoint.activeInHierarchy)
        {
            exitPoint.SetActive(true);  
        }
    }
   
}
