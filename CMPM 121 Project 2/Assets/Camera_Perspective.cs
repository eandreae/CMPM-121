using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Perspective : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwitchPerspective(){
        Debug.Log("SwitchPerspective was called!!!");
        // Flip the sign of the depths
        this.GetComponent<Camera>().depth *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
