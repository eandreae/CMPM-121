﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headlights : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Light>().intensity = 0.0f;   
    }

    public void ChangeHeadlights(){
        // Toggle the headlights
        if( this.GetComponent<Light>().intensity == 0.0f ){
            this.GetComponent<Light>().intensity += 1.0f;
        }
        else {
            this.GetComponent<Light>().intensity -= 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
