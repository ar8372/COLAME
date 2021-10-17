using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class SOUNDs
{
    public string name;
    public AudioClip SongDropHere;

    [Range(0,1)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool LoopIt;


    //public bool StatusOfPlayOnAwake;  //play on awake wont work

    [NonSerialized]   ////this is to make because i always want the Audio Manager scipt to be the souce
    public AudioSource AUDIOsOURCE;
}
