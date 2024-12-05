using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    [SerializeField] public int ball = 5;
    [SerializeField] public bool s = false;
    [SerializeField] public Text levlText;
    [SerializeField] int level;
    [SerializeField] private information sc;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        levlText.text = SceneManager.GetActiveScene().name;

        if (ball <= 0)
        {


            LoadNextLevel();
        }
        if (s == true)
        {

            
            s = false;
            RestartLevel();

        }

        void LoadNextLevel()
        {
            int level = SceneManager.GetActiveScene().buildIndex + 1;
            if (level < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(level);
            }
            else
            {
                SceneManager.LoadScene(0); // Reloads the first scene or main menu
            }

            // Check if there is a next level; if not, wrap to the first level


        }
        void RestartLevel()
        {
            // Reload the current level
            PersistentData.Instance.ResetScore();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(1);

        }

    }
}
