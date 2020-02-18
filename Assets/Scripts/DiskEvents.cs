using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskEvents : MonoBehaviour
{
    public float maxSpeed = 15f;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void onGrabbed()
    {
        transform.eulerAngles = Vector3.zero;
    }

    public void onReleased()
    {
        transform.eulerAngles = Vector3.zero;
        
        if (rigidbody.velocity.magnitude > maxSpeed) {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }

    public void onGrabMove()
    {
        transform.eulerAngles = Vector3.zero;
    }

}
