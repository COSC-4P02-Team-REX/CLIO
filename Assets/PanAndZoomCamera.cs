using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanAndZoomCamera : MonoBehaviour
{
    public Camera camera;
    public float panSpeed = 30.0f;
    public float zoomSpeed = 50.0f;
    public float minZoomDistance = 250.0f;
    public float maxZoomDistance = 3000.0f;

    public float minX = -600.0f;
    public float maxX = 600.0f;
    public float minZ = -600.0f;
    public float maxZ = 300.0f;


    private Vector3 origin = Vector3.zero;
    private float currentZoomDistance;

    void Start()
    {
        camera.transform.LookAt(origin);
        currentZoomDistance = Vector3.Distance(camera.transform.position, origin);
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float adjustedPanSpeed = panSpeed * (currentZoomDistance / maxZoomDistance);
                Vector2 deltaPosition = touch.deltaPosition * adjustedPanSpeed * Time.deltaTime;
                Vector3 translation = camera.transform.right * -deltaPosition.x + camera.transform.up * -deltaPosition.y;
                translation.y = 0; // Ignore changes in Y axis

                Vector3 newPosition = camera.transform.position + translation;
                newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
                newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
                
                camera.transform.position = newPosition;
            }
        }

        else if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            float prevTouchDistance = Vector2.Distance(touch0.position - touch0.deltaPosition, touch1.position - touch1.deltaPosition);
            float currentTouchDistance = Vector2.Distance(touch0.position, touch1.position);

            float pinchDelta = prevTouchDistance - currentTouchDistance;
            float zoomDelta = pinchDelta * zoomSpeed * Time.deltaTime;

            currentZoomDistance = Mathf.Clamp(currentZoomDistance + zoomDelta, minZoomDistance, maxZoomDistance);

            Vector3 direction = (camera.transform.position - origin).normalized;
            camera.transform.position = origin + direction * currentZoomDistance;
        }
    }
}

//Parts of scripts used/inspired from learn.unity.com