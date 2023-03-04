using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopup : MonoBehaviour
{
    public GameObject card;

    public void OpenCard()
    {
        if(card != null)
        {
            card.SetActive(true);
        }
    }
}
