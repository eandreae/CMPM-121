using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject Passenger1;
    public GameObject Passenger2;
    public GameObject Passenger3;

    private GameObject Passenger;
    private GameObject clone;
    
    public Text type;
    public GameObject pickedUp;
    public GameObject jobStarted;
    public GameObject waypoint;

    void pickPassenger() {
        float random = Mathf.Floor(Random.Range(0.0f, 3.0f));
        if (random == 0.0f ){ Passenger = Passenger1; type.text = "1";}
        if (random == 1.0f ){ Passenger = Passenger2; type.text = "2";}
        if (random == 2.0f ){ Passenger = Passenger3; type.text = "3";}
        pickedUp.SetActive(false);
    }

    public void spawnPassenger() {
        pickPassenger();
        clone = Instantiate(Passenger, transform.position, transform.rotation);
        if(jobStarted.activeSelf == false){jobStarted.SetActive(true);}
        if(waypoint.activeSelf == false){waypoint.SetActive(true);}
    }
}
