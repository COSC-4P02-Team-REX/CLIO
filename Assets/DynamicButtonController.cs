using UnityEngine;
using UnityEngine.UI;

public class DynamicButtonController : MonoBehaviour
{
    public Button button;
    public string imageName;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Debug.Log("Button clicked: " + imageName);
        // Handle button click based on imageName
    }
}
