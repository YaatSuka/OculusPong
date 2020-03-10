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
    private GameObject grabber;
    private GameObject gameController;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        diskSpawn = GameObject.FindWithTag("DiskSpawn");
        lifeTime = maxLifeTime;
        grabber = GameObject.FindWithTag("HandController");
        gameController = GameObject.Find("GameController");
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
            // Add stuff
        }
        if (collision.gameObject.tag == "Wall") {
            // Make some particles effects + sound
            GetComponent<DiskSounds>().PlayWallImpact();
        }
        if (collision.gameObject.name == "WallBack") {
            Destroy(gameObject);
            diskSpawn.GetComponent<DiskSpawn>().spawn();
            gameController.GetComponent<LifeController>().decreaseLife();
            GetComponent<DiskSlower>().resetTime();
        }
    }
}
