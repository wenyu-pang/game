using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class information : MonoBehaviour
{
    [SerializeField] public Text scoreText;
    //[SerializeField] public Text PlayerNameText;
    [SerializeField] public int scored = 0;
    // Start is called before the first frame update



    // Update is called once per frame
    public void Update()
    {
        //scoreText.text = "score: " + ((int)scored).ToString();
        scoreText.text = "score: " + PersistentData.Instance.getScore();
       
    }



}

