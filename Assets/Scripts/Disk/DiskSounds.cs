using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DiskSounds : MonoBehaviour
{
     public AudioSource wallImpact;

    void Start()
    {
        wallImpact = GetComponent<AudioSource>();
    }

    public void PlayWallImpact()
    {
        wallImpact.Play(0);
    }
}
