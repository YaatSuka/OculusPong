using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : Target
{    
    public float speedMin = -100.0f;
    public float speedMax = 100.0f;
    public float rotationSpeed = 1.0f;
    public float minDistance = 8.0f;
    public float lifeTime = 30;
    
    private bool collision = false;
    private bool hit = false;
    private float remainTime;
    private GameObject player;
    private Rigidbody rb;
    private GameObject gameController;
 
     // Use this for initialization
     void Start ()
     {
         remainTime = lifeTime;
         player = GameObject.FindWithTag("Player");
         rb = GetComponent<Rigidbody>();
         gameController = GameObject.Find("GameController");
         rotationSpeed = (Random.Range(0, 2) == 0) ? rotationSpeed : -rotationSpeed - 1;

         InvokeRepeating("Move", 0.0f, 2.0f);
     }
     
     // Update is called once per frame
     void Update ()
     {
         remainTime -= Time.deltaTime;
         if (remainTime <= 0) {
             Destroy(gameObject);
         }

         transform.Rotate(new Vector3(0.0f, rotationSpeed, 0.0f), Space.Self);
     }

     void Move()
     {
         float x = Random.Range(speedMin, speedMax);
         float y = Random.Range(speedMin, speedMax);
         float z = (Mathf.Abs(transform.position.z - player.transform.position.z) <= minDistance) ? Random.Range(speedMin, 0) : Random.Range(speedMin, speedMax);

        if (collision) {
            x *= -1;
            y *= -1;
        }

        // Cancel forces
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

         rb.AddForce(new Vector3(x, y, z));
     }

     void OnCollisionEnter(Collision col)
     {
        collision = true;
        if (col.gameObject.tag == "Disk" && !hit) {
            hit = true;
            gameController.GetComponent<ScoreController>().AddScore(value);
            Destroy(gameObject);
        }
     }

     void OnCollisionExit()
     {
        collision = false;
     }
}
