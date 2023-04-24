using UnityEngine;

public class maincamera : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}