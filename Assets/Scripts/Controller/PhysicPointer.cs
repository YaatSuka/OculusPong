using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicPointer : MonoBehaviour
{
    public float defaultLenght = 3.0f;

    private LineRenderer lineRenderer = null;

    private void Awake() {
        
    }

    private void Update() {
        UpdateLenght();
    }

    private void UpdateLenght()
    {
        lineRenderer.SetPosition(0,  transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(defaultLenght);

        if (hit.collider)
            endPosition = hit.point;

        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLenght);
        return hit;
    }

    private Vector3 DefaultEnd(float lenght)
    {
        return transform.position + (transform.forward * lenght);
    }
}
