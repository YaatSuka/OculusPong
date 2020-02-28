using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public GameObject[] targets;
    public float xMax = 12.0f;
    public float yMax = 3.0f;
    public float zMax = 9.0f;
    public int maxTargets = 6;
    public int maxBadTargets = 3;

    private float waitTime = 0.2f;
    private float remainTime;

    // Start is called before the first frame update
    void Start()
    {
        remainTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainTime -= Time.deltaTime;
        if (remainTime <= 0 && GameObject.FindGameObjectsWithTag("Target").Length < maxTargets) {
            Spawn();
            remainTime = waitTime;
        }
    }

    int nbBadTarget()
    {
        int nb = 0;
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        for (var i = 0; i < targets.Length; i++) {
            if (targets[i].GetComponent<Target>().value < 0) {
                nb++;                
            }
        }
        return nb;
    }

    bool isBadTarget(int type)
    {
        return (targets[type].GetComponent<Target>().value < 0) ? true : false;
    }

    void Spawn()
    {
        int type = Random.Range(0, targets.Length);
        while (nbBadTarget() >= maxBadTargets && isBadTarget(type)) {
            type = Random.Range(0, targets.Length);
        }

        float x = Random.Range(transform.position.x, transform.position.x + xMax);
        float y = Random.Range(transform.position.y, transform.position.y + yMax);
        float z = Random.Range(transform.position.z, transform.position.z + zMax);

        Instantiate(targets[type], new Vector3(x, y, z), transform.rotation, transform);
    }
}
