using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Part of this code is sourced from here:
// https://www.youtube.com/watch?v=VzTZMzZKHlM

public class CarAudio : MonoBehaviour
{

    AudioSource audioSource;
    private float minPitch = 0.4f;
    public GameObject speedTracker;
    private float pitchFromCar;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
    }

    // Update is called once per frame
    void Update()
    {
        var transform = speedTracker.GetComponent<Transform>();
        var position = transform.position;
        float speed = Mathf.Abs(Mathf.Floor(position.x));
        pitchFromCar = speed * 2;

        float adjusted = speed / 50;

        float pitch = minPitch + adjusted;

        audioSource.pitch = pitch;
        
    }
}
