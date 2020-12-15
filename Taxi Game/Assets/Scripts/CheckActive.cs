using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActive : MonoBehaviour
{
    public GameObject button;
    public GameObject jobStarted;

    void Update()
    {
        if (jobStarted.activeSelf == false){
            if(button.activeSelf == false){button.SetActive(true);}
        }
        else {
            if(button.activeSelf == true){button.SetActive(false);}
        }
    }
}
