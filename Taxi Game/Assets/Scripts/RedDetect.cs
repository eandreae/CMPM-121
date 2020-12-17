using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDetect : MonoBehaviour
{

    public FadeOut fadeScript;

    public GameObject redLights;

    void OnTriggerEnter(Collider collider)
    {
        if ( redLights.activeSelf == true )
        {
            fadeScript.ResetTime("ranRed");

            FindObjectOfType<AudioManager>().Play("Beepbeep");

        }
    }
}
