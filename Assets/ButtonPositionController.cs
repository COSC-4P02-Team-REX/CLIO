using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ButtonPositionController : MonoBehaviour
{
    public GameObject trackedImageObject;
    private ARTrackedImage trackedImage;
    private DynamicButtonController buttonController;

    void Start()
    {
        trackedImage = trackedImageObject.GetComponent<ARTrackedImage>();
        buttonController = GetComponent<DynamicButtonController>();
    }

    void Update()
    {
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            // Update the button position to be in the middle of the tracked image
            Vector3 buttonPosition = trackedImage.transform.position;
            transform.position = buttonPosition;

            // Set the button's imageName based on the detected image
            buttonController.imageName = trackedImage.referenceImage.name;

            // Activate the button only after the position is updated
            if (!gameObject.activeInHierarchy)
            {
                gameObject.SetActive(true);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
