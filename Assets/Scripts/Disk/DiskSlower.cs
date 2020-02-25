using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSlower : MonoBehaviour
{
    public float slowDistance = 8.0f;
    public float timeScale = 0.4f;
    
    private GameObject player;
    private bool diskGoBack = false;
    private bool isGrabbed = false;
    private Vector3 diskLastPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        diskLastPos = transform.position;
        InvokeRepeating("checkDiskDirection", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isGrabbed && diskGoBack && Vector3.Distance(player.transform.position, transform.position) <= slowDistance) {
        if (!isGrabbed && diskGoBack && transform.position.z >= (player.transform.position.z - slowDistance)) {
            Time.timeScale = timeScale;
            Application.targetFrameRate = 1200;
        } else if (transform.position.z > player.transform.position.z || !diskGoBack) {
            Time.timeScale = 1.0f;
            Application.targetFrameRate = -1;
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
        Application.targetFrameRate = -1;
        diskGoBack = false;
        isGrabbed = false;
    }

    public void onGrabbed()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = -1;
        diskGoBack = false;
        isGrabbed = true;
    }
}
