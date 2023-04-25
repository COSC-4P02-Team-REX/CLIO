using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;
    public Button switchButton;
    public Button backButton;
    public GameObject arSession;
    public Vector3 newPosition;
    public Quaternion newRotation;

    void Start()
    {
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;

        switchButton.onClick.AddListener(SwitchCamera);
        backButton.interactable = true;
    }

    void SwitchCamera()
    {
        mainCamera.enabled = !mainCamera.enabled;
        secondaryCamera.enabled = !secondaryCamera.enabled;
        backButton.interactable = true;

        TransformARSession();
    }

    void TransformARSession()
    {
        arSession.transform.position = newPosition;
        arSession.transform.rotation = newRotation;
    }
}
