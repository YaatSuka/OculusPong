using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTarget : MonoBehaviour
{
    public float RotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        RotationSpeed = (Random.Range(0, 2) == 0) ? RotationSpeed : -RotationSpeed - 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, RotationSpeed, 0.0f), Space.Self);
    }
}
