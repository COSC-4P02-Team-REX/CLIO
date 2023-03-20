using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject[] buttonsToToggle;

    private bool buttonsActive = false;

    private void Start()
    {
        // Set all three buttons to be inactive
        foreach (GameObject button in buttonsToToggle)
        {
            button.SetActive(false);
        }
    }

    public void OnClick()
    {
        // Toggle the visibility of the three buttons
        buttonsActive = !buttonsActive;

        foreach (GameObject button in buttonsToToggle)
        {
            button.SetActive(buttonsActive);
        }
    }
}

