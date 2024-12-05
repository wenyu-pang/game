using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Buttonfunction : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play() {
        string s = playerNameInput.text;
        PersistentData.Instance.ResetScore();
        PersistentData.Instance.setName(s);
        SceneManager.LoadScene("level1");

    }
    public void backmenu()
    {
        SceneManager.LoadScene("main menu");
    }

}
