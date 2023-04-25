using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher2 : MonoBehaviour
{
    public Camera mainCamera;
    public List<Camera> arCameras;
    public Button backButton;

    void Start()
    {
        mainCamera.enabled = true;
        foreach (Camera arCamera in arCameras)
        {
            arCamera.enabled = false;
        }

        backButton.onClick.AddListener(SwitchToMainCamera);
        backButton.interactable = false;
    }

    void SwitchToMainCamera()
    {
        mainCamera.enabled = true;
        foreach (Camera arCamera in arCameras)
        {
            arCamera.enabled = false;
        }
        backButton.interactable = false;
    }
}
