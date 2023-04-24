using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minZoomDistance = 200f;
    public float maxZoomDistance = 1000;
    public float zoomSpeed = 0.65f;
    public float panSpeed = 0.4f;

    public float minX = -300f;
    public float maxX = 300f;
    public float minZ = -1000;
    public float maxZ = -200f;
    public float minY = 400f;
    public float maxY = 1500f;

    private Vector2 touchStart;
    private float startDistance;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.transform.position = new Vector3(0, 1500, -1000);
        cam.transform.LookAt(new Vector3(0, 0, 0));
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = touch.deltaPosition;
                Vector3 moveDirection = new Vector3(-touchDeltaPosition.x, 0, -touchDeltaPosition.y) * panSpeed;

                Vector3 newPosition = cam.transform.position + moveDirection;

                newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
                newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

                cam.transform.position = newPosition;
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                startDistance = Vector2.Distance(touchZero.position, touchOne.position);
            }

            if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
                float pinchAmount = (currentDistance - startDistance) * zoomSpeed;

                Vector3 zoomDirection = cam.transform.forward * pinchAmount;
                Vector3 newPosition = cam.transform.position + zoomDirection;

                newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
                newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

                cam.transform.position = newPosition;
                startDistance = currentDistance;
            }
        }
    }
}
