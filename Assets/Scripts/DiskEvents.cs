using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskEvents : MonoBehaviour
{
    public float maxSpeed = 10.0f;
    public float maxLifeTime = 10.0f;
    private float lifeTime;
    private bool hasBeenGrabbed = false;
    private Rigidbody rigidbody;
    private GameObject diskSpawn;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        diskSpawn = GameObject.FindWithTag("DiskSpawn");
        lifeTime = maxLifeTime;
    }

    void Update()
    {
        if (hasBeenGrabbed) {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0) {
                diskSpawn.GetComponent<DiskSpawn>().spawn();
                Destroy(gameObject);
            }
        }
    }

    public void onGrabbed()
    {
        transform.eulerAngles = Vector3.zero;
        lifeTime = maxLifeTime;
        hasBeenGrabbed = true;
    }

    public void onReleased()
    {
        //transform.eulerAngles = Vector3.zero;
        
        if (rigidbody.velocity.magnitude > maxSpeed) {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }

    public void onGrabMove()
    {
        //transform.eulerAngles = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target") {
            Destroy(collision.gameObject);
            // Add some particles effects + sound
        }
        if (collision.gameObject.tag == "Wall") {
            // Make some particles effects + sound
        }
    }
}
