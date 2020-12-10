using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearLights : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Light>().intensity = 0.0f;
        this.GetComponent<Light>().intensity = 1.0f;
        
    }

    public void ChangeRearlights(){
        // Toggle the rearlights
        if( this.GetComponent<Light>().intensity == 0.01f ){
            this.GetComponent<Light>().intensity = 1.0f;
        }
        else {
            this.GetComponent<Light>().intensity = 0.01f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
