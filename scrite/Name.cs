using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    [SerializeField] public Text PlayerNameText;

    private void Start()
    {
        Display();
    }

    private void Display()
    {
        PlayerNameText.text = "PalyerName: " + PersistentData.Instance.getName() + "!";
    }
}
