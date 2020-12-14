using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobManager : MonoBehaviour
{

    public GameObject sp1; public GameObject dp1;
    public GameObject sp2; public GameObject dp2;
    public GameObject sp3; public GameObject dp3;
    public GameObject sp4; public GameObject dp4;
    public GameObject sp5; public GameObject dp5;

    public GameObject Passenger1;
    public GameObject Passenger2;
    public GameObject Passenger3;

    private GameObject Passenger;
    private GameObject clone;

    public Text type;
    public GameObject pickedUp;
    public GameObject jobStarted;
    public GameObject droppedOff;
    private GameObject waypoint;
    private GameObject dWaypoint;
    private bool d_spawned = false;

    private float NUM_SPOTS = 3;

    private GameObject Start;
    private GameObject Destination;

    public void beginJob() {
        resetPoints();
        pickSpawn();
        spawnPassenger();
    }

    void endJob() {
        pickDestination();
        spawnDWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(pickedUp.activeSelf == true && d_spawned == false){
            endJob();
        }
    }

// Helper functions
    void resetPoints() {
        pickedUp.SetActive(false);
        droppedOff.SetActive(false);
        d_spawned = false;
    }

    void pickSpawn() {
        float random = Mathf.Floor(Random.Range(0.0f, NUM_SPOTS));
        if (random == 0.0f ){Start = sp1;}
        if (random == 1.0f ){Start = sp2;}
        if (random == 2.0f ){Start = sp3;}
        Debug.Log(random);
    }

    void pickDestination() {
        float random = Mathf.Floor(Random.Range(0.0f, NUM_SPOTS));
        if (random == 0.0f ){Destination = dp1;}
        if (random == 1.0f ){Destination = dp2;}
        if (random == 2.0f ){Destination = dp3;}
    }

    void spawnDWaypoint() {
        var transform = Destination.GetComponent<Transform>();
        dWaypoint = Destination.transform.Find("DestinationTrigger").gameObject;
        if(dWaypoint.activeSelf == false){dWaypoint.SetActive(true);}
        Debug.Log(dWaypoint.activeSelf);
        d_spawned = true;
    }

    public void spawnPassenger() {
        pickPassenger();
        var transform = Start.GetComponent<Transform>();
        waypoint = Start.transform.Find("WaypointTrigger").gameObject;
        clone = Instantiate(Passenger, transform.position, transform.rotation);
        clone.transform.Rotate(0.0f, transform.rotation.y-90.0f, 0.0f, 0.0f);
        if(jobStarted.activeSelf == false){jobStarted.SetActive(true);}
        if(waypoint.activeSelf == false){waypoint.SetActive(true);}
    }

    void pickPassenger() {
        float random = Mathf.Floor(Random.Range(0.0f, 3.0f));
        if (random == 0.0f ){ Passenger = Passenger1; type.text = "1";}
        if (random == 1.0f ){ Passenger = Passenger2; type.text = "2";}
        if (random == 2.0f ){ Passenger = Passenger3; type.text = "3";}
        pickedUp.SetActive(false);
    }
}
