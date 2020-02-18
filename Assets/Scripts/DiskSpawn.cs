using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSpawn : MonoBehaviour
{
    public GameObject disk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void spawn()
    {
        Instantiate(disk, transform.position, Quaternion.identity);
    }
}
