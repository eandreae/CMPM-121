using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobManager : MonoBehaviour
{

    public GameObject SpawnPoints;
    public GameObject Destinations;

    public GameObject Passenger1;
    public GameObject Passenger2;
    public GameObject Passenger3;

    private GameObject Passenger;
    private GameObject clone;

    public Text type;
    public GameObject pickedUp;
    public GameObject jobStarted;
    public GameObject droppedOff;

    public Text WaypointData;

    private GameObject waypoint;
    private GameObject dWaypoint;
    private bool d_spawned = false;

    private float NUM_SPOTS = 100;

    private GameObject Start;
    private GameObject Destination;

    public void beginJob() {
        resetPoints();
        pickSpawn();
        spawnPassenger();
        FindObjectOfType<AudioManager>().Play("Buuh");
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
        float random = Mathf.Floor(Random.Range(1.0f, NUM_SPOTS));
        Debug.Log(random);
        Start = SpawnPoints.transform.Find(random.ToString()).gameObject;
        WaypointData.text = random.ToString();
    }

    void pickDestination() {
        float random = Mathf.Floor(Random.Range(0.0f, NUM_SPOTS));
        Debug.Log(random);
        Destination = Destinations.transform.Find(random.ToString()).gameObject;
        WaypointData.text = random.ToString();
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
        if (random == 3.0f ){ Passenger = Passenger3; type.text = "3";}
        pickedUp.SetActive(false);
    }
}
