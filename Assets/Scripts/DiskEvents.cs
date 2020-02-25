using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskEvents : MonoBehaviour
{
    public float maxSpeed = 20.0f;
    public float maxLifeTime = 10.0f;
    private float lifeTime;
    private bool hasBeenGrabbed = false;
    private bool isGrabbed = false;
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

        if (!isGrabbed && hasBeenGrabbed) {
            transform.Rotate(new Vector3(0.0f, 10.0f, 0.0f), Space.Self);
        }
    }

    public void onGrabbed()
    {
        transform.eulerAngles = Vector3.zero;
        lifeTime = maxLifeTime;
        hasBeenGrabbed = true;
        isGrabbed = true;
    }

    public void onReleased()
    {
        rigidbody.velocity *= 2;

        if (rigidbody.velocity.magnitude > maxSpeed) {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }

        isGrabbed = false;
    }

    public void onGrabMove()
    {
        //transform.eulerAngles = Vector3.zero;
        lifeTime = maxLifeTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target") {
            Destroy(collision.gameObject);
            // Add some particles effects + sound
        }
        if (collision.gameObject.tag == "Wall") {
            // Make some particles effects + sound
            GetComponent<DiskSounds>().PlayWallImpact();
        }
    }
}
