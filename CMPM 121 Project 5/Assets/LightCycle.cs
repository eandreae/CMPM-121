using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycle : MonoBehaviour
{

    public GameObject redLights_H;
    public GameObject yellowLights_H;
    public GameObject greenLights_H;
    public GameObject redLights_V;
    public GameObject yellowLights_V;
    public GameObject greenLights_V;

    // Used online resources to get this code.
    // Source : 
    // https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#timer

    private bool progressing_H = false;
    private bool progressing_V = false;
    private float CYCLE_TIME = 5.0f;
    private float timeRemaining_H = 0.0f;
    private float timeRemaining_V = 0.0f;
    private bool horizontalFirst;

    void Start()
    {
        // Lights start disabled
        redLights_H.SetActive(false);
        yellowLights_H.SetActive(false);
        greenLights_H.SetActive(false);
        redLights_V.SetActive(false);
        yellowLights_V.SetActive(false);
        greenLights_V.SetActive(false);
        // Pick the order of lights.
        horizontalFirst = pickFirst();
        Debug.Log(horizontalFirst);
        // if true, horizontal first.
        // if false, vertical first.
        if ( horizontalFirst ){
            // Enable greenLights_H, Enable redLights_V.
            if (greenLights_H.activeSelf == false){greenLights_H.SetActive(true);}
            if (redLights_V.activeSelf == false){redLights_V.SetActive(true);}
            progressing_H = true;
            timeRemaining_H = CYCLE_TIME;
        }
        else {
            // Enable greenLights_V, Enable redLights_H.
            if (greenLights_V.activeSelf == false){greenLights_V.SetActive(true);}
            if (redLights_H.activeSelf == false){redLights_H.SetActive(true);}
            progressing_V = true;
            timeRemaining_V = CYCLE_TIME;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (progressing_H && !progressing_V){
            if ( timeRemaining_H > 3.0f ) {
                // Subtract the time by deltatime.
                timeRemaining_H -= Time.deltaTime;
                // Enable green lights, disable red lights.
                if (greenLights_H.activeSelf == false){greenLights_H.SetActive(true);}
                if (redLights_H.activeSelf == true){redLights_H.SetActive(false);}
            }
            else if ( timeRemaining_H > 0.0f ){
                // Subtract the time by deltatime.
                timeRemaining_H -= Time.deltaTime;
                // Enable yellow lights, disable green lights.
                if (yellowLights_H.activeSelf == false){yellowLights_H.SetActive(true);}
                if (greenLights_H.activeSelf == true){greenLights_H.SetActive(false);}
            }
            else {
                // Set time remaining_H to 0.
                timeRemaining_H = 0.0f;
                // Set time remaining_V to CYCLE_TIME.
                timeRemaining_V = CYCLE_TIME;
                // Set progressing_H to false
                progressing_H = false;
                // Set progressing_V to true
                progressing_V = true;
                // Enable red lights, disable yellow lights.
                if (redLights_H.activeSelf == false){redLights_H.SetActive(true);}
                if (yellowLights_H.activeSelf == true){yellowLights_H.SetActive(false);}
            }
        }
        if (progressing_V && !progressing_H){
            if ( timeRemaining_V > 3.0f ) {
                // Subtract the time by deltatime.
                timeRemaining_V -= Time.deltaTime;
                // Enable green lights, disable red lights.
                if (greenLights_V.activeSelf == false){greenLights_V.SetActive(true);}
                if (redLights_V.activeSelf == true){redLights_V.SetActive(false);}
            }
            else if ( timeRemaining_V > 0.0f ){
                // Subtract the time by deltatime.
                timeRemaining_V -= Time.deltaTime;
                // Enable yellow lights, disable green lights.
                if (yellowLights_V.activeSelf == false){yellowLights_V.SetActive(true);}
                if (greenLights_V.activeSelf == true){greenLights_V.SetActive(false);}
            }
            else {
                // Set time remaining_V to 0.
                timeRemaining_V = 0.0f;
                // Set time remaining_H to CYCLE_TIME.
                timeRemaining_H = CYCLE_TIME;
                // Set progressing_V to false
                progressing_V = false;
                // Set progressing_H to true
                progressing_H = true;
                // Enable red lights, disable yellow lights.
                if (redLights_V.activeSelf == false){redLights_V.SetActive(true);}
                if (yellowLights_V.activeSelf == true){yellowLights_V.SetActive(false);}
            }
        }
    }

    bool pickFirst() {
        float random = Random.Range(0.0f, 1.0f);
        if ( random > 0.5f ){
            return true;
        }
        else {
            return false;
        }
    }
}
