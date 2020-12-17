using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{

    // Used online resources to get this code.
    // Source : 
    // https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#timer

    private bool progressing = false;
    private float timeRemaining = 3;

    public Text timeText;

    public GameObject gameOverObject;

    public GameOverMenu gameOverScript;

    void Start()
    {
        progressing = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Check if the progressing is true.
        if ( progressing ){
            // Check if the time remaining isn't zero.
            if ( timeRemaining > 1 ){
                // Subtract the time by deltatime.
                timeRemaining -= Time.deltaTime;
                // Display the time remaining.
                displayTime(timeRemaining);
            }
            else {
                // Otherwise, the progress has finished.
                string gameOver = "Game Over!";
                // Set the time remaining to zero.
                timeRemaining = 0;
                // Set progressing to false.
                progressing = false;
                displayTime(gameOver);

                
            }
        }
        else
        {
            if ( gameOverObject.activeSelf == false )
            {
                gameOverObject.SetActive(true);
                gameOverScript.GameOver();
            }
        }
    }

    void displayTime(float time) {

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void displayTime(string s) {
        timeText.text = s;
    }
}
