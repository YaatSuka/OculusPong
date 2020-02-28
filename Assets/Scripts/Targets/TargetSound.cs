using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TargetSound : MonoBehaviour
{
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 1.0f);
    }
}
