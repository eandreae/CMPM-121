using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject GameOverUI;
    public GameObject UIElements1;
    public GameObject UIElements2;

    public Text scoreText;
    public Text highScoreText;
    public Text redsRan;
    public Text passengersRanOver;

    public GameObject mainCamera;
    public GameObject gameOverCamera;

    public FadeOut fadeScript;

    public void GameOver ()
    {
        mainCamera.GetComponent<Camera>().enabled = false;
        mainCamera.GetComponent<AudioListener>().enabled = false;
        gameOverCamera.GetComponent<Camera>().enabled = true;

        GameOverUI.SetActive(true);
        UIElements1.SetActive(false);
        UIElements2.SetActive(false);

        int score = fadeScript.getScore();
        int reds = fadeScript.getReds();
        int peds = fadeScript.getPassengersRanOver();

        int highScore = PlayerPrefs.GetInt("high-score", 0);

        if ( score > highScore )
        {
            // Save high score
            PlayerPrefs.SetInt("high-score", score);
        }

        highScore = PlayerPrefs.GetInt("high-score", 0);

        scoreText.text = "FINAL SCORE : " + score.ToString();
        highScoreText.text = "HIGH SCORE : " + highScore.ToString();
        
        if ( reds == 1 )
        {
            redsRan.text = "1 RED LIGHT RAN";
        }
        else
        {
            redsRan.text = reds.ToString() + " RED LIGHTS RAN";
        }

        if ( peds == 1 )
        {
            passengersRanOver.text =  "1 PASSENGER RAN OVER";
        }
        else
        {
            passengersRanOver.text = peds.ToString() + " PASSENGERS RAN OVER";
        }
    }
}
