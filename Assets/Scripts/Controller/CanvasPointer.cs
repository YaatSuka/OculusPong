using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasPointer : MonoBehaviour
{

    public float defaultLenght = 3.0f;

    public EventSystem eventSystem = null;
    public StandaloneInputModule inputModule = null;

    private LineRenderer lineRenderer = null;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        UpdateLenght();
    }

    private void UpdateLenght()
    {
        lineRenderer.SetPosition(0,  transform.position);
        lineRenderer.SetPosition(1, GetEnd());
    }

    private Vector3 GetEnd()
    {
        float distance = GetCanvasDistance();
        Vector3 endPosition = CalculateEnd(defaultLenght);

        if(distance != 0.0f)
            endPosition = CalculateEnd(distance);

        return endPosition;
    }

    private float GetCanvasDistance()
    {

        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = inputModule.inputOverride.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, results);

        RaycastResult closesResult = FindFirstRacast(results);
        float distance = closesResult.distance;

        distance = Mathf.Clamp(distance, 0.0f, defaultLenght);
        return distance;
    }

    private RaycastResult FindFirstRacast(List<RaycastResult> results){
        foreach(RaycastResult result in results){
            if (!result.gameObject)
                continue;
            return result;
        }

        return new RaycastResult();
    }

    private Vector3 CalculateEnd(float lenght)
    {
        return transform.position + (transform.forward * lenght);
    }
}
