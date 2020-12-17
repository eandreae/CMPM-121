using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{

    public float speed        = 0.0f;
    private float acceleration = 10.0f;
    private float rotateSpeed  = 60.0f;
    private float MAX_SPEED = 30.0f;

    public GameObject speedTracker;
    public GameObject rearLights;
    public GameObject reverseLights;

    public GameObject Passenger1;
    public GameObject Passenger2;
    public GameObject Passenger3;

    private GameObject Passenger;
    private Vector3 thePosition;
    private GameObject clone;

    public Text type;
    public GameObject pickedUp;
    public GameObject inRange;
    public GameObject jobStarted;
    public GameObject droppedOff;

    public FadeOut fadeScript;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("CarStart");
    }

    void OnMouseDown() {

        if (pickedUp.activeSelf == true && inRange.activeSelf == true){
            if (type.text == "1"){Passenger = Passenger1;}
            if (type.text == "2"){Passenger = Passenger2;}
            if (type.text == "3"){Passenger = Passenger3;}

            Vector3 heightOffset = new Vector3(0, 2, 0);
            thePosition = transform.TransformPoint(Vector3.right * 2);
            thePosition += heightOffset;
            clone = Instantiate(Passenger, thePosition, this.transform.rotation);
            var cloneBody = clone.GetComponent<Rigidbody>();
            cloneBody.velocity = transform.TransformDirection(Vector3.right * 10);
            clone.transform.Rotate(0.0f, transform.rotation.y+90.0f, 0.0f, 0.0f);

            if(pickedUp.activeSelf == true){pickedUp.SetActive(false);}
            if(jobStarted.activeSelf == true){jobStarted.SetActive(false);}
            if(droppedOff.activeSelf == false){droppedOff.SetActive(true);}

            Object.Destroy(clone, 5.0f);

            fadeScript.ResetTime("dropOff");

            FindObjectOfType<AudioManager>().Play("CarDoor");
        }
    }

    public void updateSpeedTracker() {
        var transform = speedTracker.GetComponent<Transform>();
        var position = transform.position;
        position.x = this.speed;
        transform.position = position;
    }

    public void switchOn(GameObject lights) {
        if(lights.activeSelf == false){lights.SetActive(true);}
    }

    public void switchOff(GameObject lights) {
        if(lights.activeSelf == true){lights.SetActive(false);}
    }

    // Update is called once per frame
    void Update()
    {

        // From the Unity documentation on simplemove.
        CharacterController controller = GetComponent<CharacterController>();

        transform.Rotate(
            0.0f, 
            Input.GetAxis("Horizontal") * this.rotateSpeed * Time.deltaTime,
            0.0f
        );

        if ( Input.GetAxis("Vertical") > 0 && this.speed < MAX_SPEED ){

            if ( this.speed >= 0 ){this.speed += acceleration * Time.deltaTime;}
            if ( this.speed < 0 ){
                this.speed += acceleration * Time.deltaTime * 2.0f;
            }
            switchOff(rearLights);
            switchOff(reverseLights);
            
        }

        if (Input.GetAxis("Vertical") == 0 ){

            if ( this.speed > 0 ) {
                this.speed -= acceleration/1.25f * Time.deltaTime;
                if ( this.speed < 1 ){ this.speed = 0; }
                switchOff(rearLights);
                switchOff(reverseLights);
            }
            if ( this.speed < 0 ) {
                this.speed += acceleration/1.25f * Time.deltaTime;
                if ( this.speed > 1 ) { this.speed = 0; }
                switchOff(rearLights);
                switchOff(reverseLights);
            }
        }

        if ( Input.GetAxis("Vertical") < 0 && this.speed > -18f){
            if ( this.speed <= 0 ){this.speed -= acceleration/2.0f * Time.deltaTime;}
            if ( this.speed > 0 ){
                this.speed -= acceleration * Time.deltaTime * 2.0f;
            }
            if (this.speed < 0.0f ){
                switchOff(rearLights);
                switchOn(reverseLights);
            }
            else {
                switchOff(reverseLights);
                switchOn(rearLights);
            }
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = this.speed;
        controller.SimpleMove(forward * curSpeed);

        updateSpeedTracker();
        
        
    }

    
}
