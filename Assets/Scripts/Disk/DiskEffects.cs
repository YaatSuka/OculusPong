using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskEffects : MonoBehaviour
{
    public GameObject FireworksAll;
    
    void OnCollisionWithWall()
    {
        GameObject firework = Instantiate(FireworksAll, transform.position, Quaternion.identity);
        firework.GetComponent<ParticleSystem>().Play();
    }
}
