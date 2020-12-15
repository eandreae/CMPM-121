using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dTrigger : MonoBehaviour
{
    public GameObject inRange;
    public GameObject pickedUp;
    public GameObject itself;
    public GameObject droppedOff;

    void Start()
    {
        var mesh = this.GetComponent<Renderer>();
        mesh.enabled = false;
    }

    public void OnTriggerEnter(Collider collider){
        if (collider.GetComponent<player>() != null ){
            var mesh = this.GetComponent<Renderer>();
            mesh.enabled = false;
            if(inRange.activeSelf == false){inRange.SetActive(true);}
        }
    }

    public void OnTriggerExit(Collider collider){
        if (collider.GetComponent<player>() != null ){
            var mesh = this.GetComponent<Renderer>();
            mesh.enabled = true;
            if(inRange.activeSelf == true){inRange.SetActive(false);}
        }
    }

    void Update()
    {
        if(droppedOff.activeSelf == true){
            inRange.SetActive(false);
            itself.SetActive(false);
        }
        else {
            var mesh = this.GetComponent<Renderer>();
            if (mesh.enabled == false && inRange.activeSelf == false)
            {mesh.enabled = true;}
        }
    }
}
