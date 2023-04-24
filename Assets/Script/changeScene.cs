using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changeScene : MonoBehaviour
{
    public void loadScene(string scene)
    {
    SceneManager.LoadScene(scene);
    }

    public void GoToMainMenu()
    {
    SceneManager.LoadScene("Main Menu");
    }

    public void GoTo3DListing()
    {
    SceneManager.LoadScene("3D-Listing");
    }
}

