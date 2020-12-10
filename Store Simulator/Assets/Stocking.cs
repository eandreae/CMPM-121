using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stocking : MonoBehaviour
{
    // Used online resources to get this code.
    // Source : 
    // https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#timer

    public GameObject NotBankrupt;
    private float timeRemaining = 0;
    private bool progressing = false;

    public GameObject tracker;
    public TextMeshProUGUI moneyData;

    public GameObject full;
    public GameObject half;
    public GameObject low;

    void Start()
    {
        // Shelves start unstocked.
        progressing = false;
        timeRemaining = 0;

        full.SetActive(false);
        half.SetActive(false);
        low.SetActive(false);

        updateMoney();

    }

    // Update is called once per frame
    void Update()
    {
        if ( NotBankrupt.activeSelf == false ){
            Object.Destroy(full, 0.1f);
            Object.Destroy(half, 0.1f);
            Object.Destroy(low, 0.1f);
            progressing = false;
        }
        // Check if the progressing is true.
        if ( progressing ){
            // Check if the time remaining isn't zero.
            if ( timeRemaining > 12.0f ) {
                // Subtract the time by deltatime.
                timeRemaining -= Time.deltaTime;
            }
            else if ( timeRemaining < 12.0f && timeRemaining > 6.0f ){
                // Subtract the time by deltatime.
                timeRemaining -= Time.deltaTime;
                // Disable full stock, enable half stock.
                if(full.activeSelf == true){full.SetActive(false);}
                if(half.activeSelf == false){
                    half.SetActive(true);
                    add(Mathf.Floor(Random.Range(20.0f, 30.0f)));
                }
                
            }
            else if ( timeRemaining < 6.0f && timeRemaining > 0.2f ){
                // Subtract the time by deltatime.
                timeRemaining -= Time.deltaTime;
                // Disable half stock, enable low stock.
                if(half.activeSelf == true){half.SetActive(false);}
                if(low.activeSelf == false){
                    low.SetActive(true);
                    add(Mathf.Floor(Random.Range(20.0f, 30.0f)));
                }
            }
            else {
                timeRemaining = 0;
                progressing = false;
                // Disable low stock.
                if(low.activeSelf == true){
                    low.SetActive(false);
                    add(Mathf.Floor(Random.Range(20.0f, 30.0f)));
                }
            }
        }
    }

    void add(float f){
        // Storing the money data in the position of an empty object.
        var transform = tracker.GetComponent<Transform>();
        var position = transform.position;
        position.x += f;
        transform.position = position;
        updateMoney();
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

    float generateNumber() {
        return Random.Range(15.0f, 25.0f);
    }

    public void StockShelves() {
        if(full.activeSelf == true || NotBankrupt.activeSelf == false ){ /* Do Nothing */ }
        else {
            if(half.activeSelf == true){ 
                sub(5.0f);
                half.SetActive(false);
            }
            else if(low.activeSelf == true) {
                sub(5.0f);
                low.SetActive(false);
            }
            else {
                sub(10.0f);
            }
            timeRemaining = generateNumber();
            progressing = true;
            full.SetActive(true);
        }
    }
}
