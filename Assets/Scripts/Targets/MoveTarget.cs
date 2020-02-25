using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{    
    public float speedMin = -100.0f;
    public float speedMax = 100.0f;
    public float rotationSpeed = 1.0f;
    public float minDistance = 8.0f;
    
    private bool collision = false;
    private GameObject player;
    private Rigidbody rb;
 
     // Use this for initialization
     void Start ()
     {
         player = GameObject.FindWithTag("Player");
         rb = GetComponent<Rigidbody>();
         rotationSpeed = (Random.Range(0, 2) == 0) ? rotationSpeed : -rotationSpeed - 1;

         InvokeRepeating("Move", 0.0f, 2.0f);
     }
     
     // Update is called once per frame
     void Update ()
     {
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

     void OnCollisionEnter()
     {
        collision = true;
     }

     void OnCollisionExit()
     {
        collision = false;
     }
}
