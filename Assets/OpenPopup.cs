using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopup : MonoBehaviour
{
    public GameObject card;

    private bool cardActive = false;

    private void Start()
    {
            card.SetActive(cardActive);
    }

    public void OnClick()
    {
        // Toggle the visibility of the three buttons
        cardActive = !cardActive;
        card.SetActive(cardActive);
    
    }
}
