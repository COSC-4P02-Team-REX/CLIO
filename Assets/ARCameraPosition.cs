using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCameraPosition : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public float heightOffset = 1.5f;

    private bool cameraPositionSet = false;

    private void Update()
    {
        if (!cameraPositionSet)
        {
            foreach (var plane in arPlaneManager.trackables)
            {
                if (plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp)
                {
                    Vector3 newPosition = new Vector3(transform.position.x, plane.transform.position.y + heightOffset, transform.position.z);
                    transform.position = newPosition;
                    cameraPositionSet = true;
                    break;
                }
            }
        }
    }
}
