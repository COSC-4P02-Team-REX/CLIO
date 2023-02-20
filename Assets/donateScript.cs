using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLink : MonoBehaviour
{
    public string link;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenURL);
    }

    private void OpenURL()
    {
        Application.OpenURL(link);
    }
}
