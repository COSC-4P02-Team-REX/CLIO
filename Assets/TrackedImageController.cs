using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImageController : MonoBehaviour
{
    [SerializeField]
    private GameObject quadPrefab;
    [SerializeField]
    private GameObject buttonPrefab;

    private ARTrackedImage trackedImage;
    private GameObject instantiatedQuad;
    private GameObject instantiatedButton;
    private DynamicButtonController buttonController;

    void Awake()
    {
        trackedImage = GetComponent<ARTrackedImage>();
    }

    void Update()
    {
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            if (instantiatedQuad == null)
            {
                instantiatedQuad = Instantiate(quadPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
            }
            else
            {
                instantiatedQuad.transform.position = trackedImage.transform.position;
                instantiatedQuad.transform.rotation = trackedImage.transform.rotation;
            }

            if (instantiatedButton == null)
            {
                instantiatedButton = Instantiate(buttonPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                buttonController = instantiatedButton.GetComponent<DynamicButtonController>();
                buttonController.imageName = trackedImage.referenceImage.name;
            }
            else
            {
                instantiatedButton.transform.position = trackedImage.transform.position;
                instantiatedButton.transform.rotation = trackedImage.transform.rotation;
            }
        }
        else
        {
            if (instantiatedQuad != null)
            {
                Destroy(instantiatedQuad);
                instantiatedQuad = null;
            }

            if (instantiatedButton != null)
            {
                Destroy(instantiatedButton);
                instantiatedButton = null;
            }
        }
    }
}
