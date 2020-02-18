using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskRebound : MonoBehaviour
{
    public Vector3 myVelocity = 5.0f;
 
    private void Update ()
    {
        // Move
        transform.position += myVelocity * Time.deltaTime;
    
        // Look in the direction it's moving in
        transform.rotation = Quaternion.LookRotation (myVelocity);
    }
    
    private void OnTriggerEnter (Collider other)
    {
        myVelocity.z *= -1;  // Flip
    }
}
