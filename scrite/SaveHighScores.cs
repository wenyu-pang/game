using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SaveHighScores : MonoBehaviour
{

    [SerializeField] const int NUM_HIGH_SCORES = 5;
    [SerializeField] const string NAME_KEY = "HighScoreName";
    [SerializeField] const string SCORE_KEY = "HighScore";

    [SerializeField] string playerName;
    [SerializeField] int playerScore;

    [SerializeField] TextMeshProUGUI[] nameTexts;
    [SerializeField] TextMeshProUGUI[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.getName();
        playerScore = PersistentData.Instance.getScore();

        SaveScore();
        DisplayHighScores();

    }

    private void SaveScore()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;

            {
                if (PlayerPrefs.HasKey(currentScoreKey))
                {
                    int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                    if (playerScore > currentScore)
                    {
                        //handle this case
                        int tempScore = currentScore;
                        string tempName = PlayerPrefs.GetString(currentNameKey);

                        PlayerPrefs.SetString(currentNameKey, playerName);
                        PlayerPrefs.SetInt(currentScoreKey, playerScore);

                        playerScore = tempScore;
                        playerName = tempName;
                    }

                }
                else
                {
                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);
                    return;
                }
            }
        }
    }

    public void DisplayHighScores()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            nameTexts[i].text = "player name:"+PlayerPrefs.GetString(NAME_KEY + i);
            scoreTexts[i].text = "Score:"+PlayerPrefs.GetInt(SCORE_KEY + i).ToString();
        }
    }

    public void ClearAllScoresAndNames()
    {
        // Loop through and delete all saved player names and scores
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            PlayerPrefs.DeleteKey(NAME_KEY + i); // Remove player name
            PlayerPrefs.DeleteKey(SCORE_KEY + i); // Remove player score
        }

        // Clear the displayed names and scores in the UI
        foreach (TextMeshProUGUI nameText in nameTexts)
        {
            nameText.text = "1 ";
        }
        foreach (TextMeshProUGUI scoreText in scoreTexts)
        {
            scoreText.text = "1 ";
        }

        // Save changes to PlayerPrefs
        PlayerPrefs.Save();
    }

}
