using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{

    public float speed        = 0.0f;
    private float acceleration = 10.0f;
    private float rotateSpeed  = 0.6f;
    private float MAX_SPEED = 30.0f;

    public TextMeshProUGUI speedometer;

    public void updateSpeedometer() {
        float speedData = Mathf.Floor(this.speed * 2.0f);
        this.speedometer.text = speedData.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        // From the Unity documentation on simplemove.
        CharacterController controller = GetComponent<CharacterController>();

        transform.Rotate(
            0.0f, 
            Input.GetAxis("Horizontal") * this.rotateSpeed,
            0.0f
        );

        if ( Input.GetAxis("Vertical") > 0 && this.speed < MAX_SPEED ){
            Debug.Log("Accelerating");

            if ( this.speed >= 0 ){this.speed += acceleration * Time.deltaTime;}
            if ( this.speed < 0 ){
                this.speed += acceleration * Time.deltaTime * 2.0f;
            }
            
        }

        if (Input.GetAxis("Vertical") == 0 ){
            Debug.Log("Decelerating");

            if ( this.speed > 0 ) {
                this.speed -= acceleration/1.25f * Time.deltaTime;
                if ( this.speed < 1 ){ this.speed = 0; }
            }
            if ( this.speed < 0 ) {
                this.speed += acceleration/1.25f * Time.deltaTime;
                if ( this.speed > 1 ) { this.speed = 0; }
            }
        }

        if ( Input.GetAxis("Vertical") < 0 && this.speed > -18f){
            Debug.Log("Reversing");
            if ( this.speed <= 0 ){this.speed -= acceleration/2.0f * Time.deltaTime;}
            if ( this.speed > 0 ){
                this.speed -= acceleration * Time.deltaTime * 2.0f;
            }
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = this.speed;
        controller.SimpleMove(forward * curSpeed);

        updateSpeedometer();
        
    }

    
}
