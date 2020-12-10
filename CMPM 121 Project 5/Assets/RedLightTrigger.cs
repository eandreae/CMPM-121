using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightTrigger : MonoBehaviour
{
    public GameObject redLights;

    void OnTriggerEnter(Collider collider) {
        if ( collider.gameObject.CompareTag("Player") ){
            Debug.Log("Collided with the player!");

            if ( redLights.activeSelf ){
                Debug.Log("Player ran a red light!");
            }
        }
    }
}
