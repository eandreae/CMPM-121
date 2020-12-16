﻿using UnityEngine.Audio;
using UnityEngine;

// Part of this code is sourced from here:
// https://www.youtube.com/watch?v=6OT43pvUyfY

[System.Serializable]
public class Sound
{

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}