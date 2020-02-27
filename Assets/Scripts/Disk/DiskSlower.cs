using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSlower : MonoBehaviour
{
    public float slowDistance = 8.0f;
    public float timeScale = 0.2f;
    
    private GameObject player;
    private bool diskGoBack = false;
    private bool isGrabbed = false;
    private Vector3 diskLastPos;
    private float fixedDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        diskLastPos = transform.position;
        fixedDeltaTime = Time.fixedDeltaTime;
        InvokeRepeating("checkDiskDirection", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrabbed && diskGoBack && transform.position.z >= (player.transform.position.z - slowDistance)) {
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
        } else if (transform.position.z > player.transform.position.z || !diskGoBack) {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
        }
    }

    void checkDiskDirection()
    {
        if (!isGrabbed) {
            if (diskLastPos.z < transform.position.z) {
                diskGoBack = true;
            } else {
                diskGoBack = false;
            }
        }
        diskLastPos = transform.position;
    }

    public void onReleased()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
        diskGoBack = false;
        isGrabbed = false;
    }

    public void onGrabbed()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
        diskGoBack = false;
        isGrabbed = true;
    }

     public void resetTime()
     {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
     }
}
