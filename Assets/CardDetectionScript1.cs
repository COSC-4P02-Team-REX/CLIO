using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class CardDeteectionScript1 : MonoBehaviour
{
    [SerializeField]
    private GameObject imageObject;

    private ARTrackedImageManager arTrackedImageManager;

    private void Awake()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            if (trackedImage.referenceImage.name == "yellow_marker")
            {
                // Instantiate the imageObject on the detected image
                var newImageObject = Instantiate(imageObject, trackedImage.transform.position, trackedImage.transform.rotation);
                newImageObject.transform.localScale = new Vector3(trackedImage.size.x, 1f, trackedImage.size.y);
            }
        }
        

        foreach (var trackedImage in args.updated)
        {
            if (trackedImage.referenceImage.name == "yellow_marker")
            {
                // Update the position and rotation of the imageObject on the detected image
                var imageObjectTransform = imageObject.transform;
                imageObjectTransform.position = trackedImage.transform.position;
                imageObjectTransform.rotation = trackedImage.transform.rotation;
                imageObjectTransform.localScale = new Vector3(trackedImage.size.x, 1f, trackedImage.size.y);
            }
        }

        foreach (var trackedImage in args.removed)
        {
            if (trackedImage.referenceImage.name == "yellow_marker")
            {
                // Destroy the imageObject on the removed image
                Destroy(imageObject);
            }
        }
    }
}
