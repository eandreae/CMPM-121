using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnimation : MonoBehaviour
{

    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim["Front Forward"].layer = 123;
        anim["Front Reverse"].layer = 123;
    }

    // Update is called once per frame
    void Update()
    {
        if ( anim.isPlaying) {
            return;
        }

        if ( Input.GetAxis("Vertical") > 0 ){
            Debug.Log("Moving Forward");
            anim.Play("Front Forward");
            anim.Play("Rear Forward");
        }

        if ( Input.GetAxis("Vertical") < 0 ){
            Debug.Log("Moving Backward");
            anim.Play("Front Reverse");
            anim.Play("Rear Reverse");
        }
    }
}
