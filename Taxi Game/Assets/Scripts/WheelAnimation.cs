using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelAnimation : MonoBehaviour
{

    private Animation anim;
    public GameObject speedTracker;
    private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim["Front Forward"].layer = 123;
        anim["Front Reverse"].layer = 123;
    }

    float getSpeed() {
        var transform = speedTracker.GetComponent<Transform>();
        var position = transform.position;
        return position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if ( anim.isPlaying) {
            return;
        }

        speed = getSpeed();

        if ( speed > 0.0f ){
            anim.Play("Front Forward");
            anim.Play("Rear Forward");
        }

        if ( speed < 0.0f ){
            anim.Play("Front Reverse");
            anim.Play("Rear Reverse");
        }
    }
}
