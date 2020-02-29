using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallImpact : MonoBehaviour
{
    public GameObject impactParticlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 contactPoint = contact.point;

        Instantiate(impactParticlePrefab, contactPoint, transform.rotation);
    }
}
