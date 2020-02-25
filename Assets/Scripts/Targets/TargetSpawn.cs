using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public GameObject[] targets;
    public float xMax = 12.0f;
    public float yMax = 3.0f;
    public float zMax = 9.0f;
    public int maxTargets = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Target").Length < maxTargets) {
            Spawn();
        }
    }

    void Spawn()
    {
        int type = Random.Range(0, targets.Length);
        float x = Random.Range(transform.position.x, transform.position.x + xMax);
        float y = Random.Range(transform.position.y, transform.position.y + yMax);
        float z = Random.Range(transform.position.z, transform.position.z + zMax);

        Instantiate(targets[type], new Vector3(x, y, z), transform.rotation, transform);
    }
}
