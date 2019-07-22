using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyScript : MonoBehaviour
{
    [SerializeField] private string KeyNumber;

    public string KeyNumber1 { get => KeyNumber; set => KeyNumber = value; }
}
