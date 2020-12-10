using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rent : MonoBehaviour
{
    // Used online resources to get this code.
    // Source : 
    // https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#timer

    private bool progressing = false;
    private float MIN_TIME = 60;
    public float WIN_CONDITION = 2500f;
    private float timeRemaining;
    private float rent = 100.0f;
    private bool bankrupt;
    private bool winner;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI rentDue;
    public TextMeshProUGUI moneyData;

    public GameObject tracker;
    public GameObject bankruptChecker;

    void Start()
    {
        progressing = true;
        timeRemaining = MIN_TIME;
        bankrupt = false;
        winner = false;
        updateRent();
    }

    // Update is called once per frame
    void Update()
    {
        bool winner = checkGoal();
        if ( winner ){
            progressing = false;
            displayTime("You win!");
        }
        // Check if the progressing is true.
        if ( progressing ){
            // Check if the time remaining isn't zero.
            if ( timeRemaining > 0 ){
                // Subtract the time by deltatime.
                timeRemaining -= Time.deltaTime;
                // Display the time remaining.
                displayTime(timeRemaining);
            }
            else {
                Debug.Log("Paying rent");
                payRent();
                bankrupt = checkBankrupt();
                if ( bankrupt ){
                    progressing = false;
                    bankruptChecker.SetActive(false);
                    displayTime("Game Over! You've gone bankrupt!");
                }
                else {
                    timeRemaining = MIN_TIME;
                }
                
            }
        }
    }

    bool checkGoal() {
        float currentMoney = getMoney();
        if (currentMoney >= WIN_CONDITION ){
            return true;
        }
        else {
            return false;
        }
    }

    bool checkBankrupt() {
        float currentMoney = getMoney();
        if (currentMoney < 0.0f ){
            return true;
        }
        else {
            return false;
        }
    }

    float getMoney() {
        var transform = tracker.GetComponent<Transform>();
        var position = transform.position;
        return position.x;
    }

    void payRent() {
        sub(rent);
        rent *= 1.5f;
        updateRent();
    }

    void displayTime(float time) {

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void displayTime(string s) {
        timeText.text = s;
    }

    void sub(float f){
        // Storing the money data in the position of an empty object.
        var transform = tracker.GetComponent<Transform>();
        var position = transform.position;
        position.x -= f;
        transform.position = position;
        updateMoney();
    }

    void updateMoney() {
        var transform = tracker.GetComponent<Transform>();
        var position = transform.position;
        moneyData.text = ("$" + position.x.ToString());
    }

    void updateRent() {
        rentDue.text = ("$" + rent.ToString());
    }
}
