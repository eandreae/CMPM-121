using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Passenger : MonoBehaviour
{

    public GameObject pickedUp;
    public GameObject inRange;
    
    void OnMouseDown(){
        if(inRange.activeSelf == true){
            Object.Destroy(this.gameObject, 0.0f);
            pickedUp.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Collided with player");
        }
    }
}
