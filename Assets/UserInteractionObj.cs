using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Input = InputWrapper.Input;

public class UserInteractionObj : MonoBehaviour {

    Animator animator;
    Vector3 prevPos = Vector3.zero;
    Vector3 posDelta = Vector3.zero;
    Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    Vector3 moveChange = new Vector3(0.0f, -0.01f, 0.0f);
    private bool isDraging = false;
    bool sizeDone = false;
    bool doneAll = false;
    int count = 0;

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update() {
       StartUpAnimation();

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            float chngX = touch.deltaPosition.x;
            float chngY = touch.deltaPosition.y;
            // Change the 50f if we want to lower or increase speed of rotation
            if (Vector3.Dot(transform.up, Vector3.up) >= 0) {
                transform.Rotate(0, -chngX * 50f * Time.deltaTime, 0);
            } else {
                transform.Rotate(0, chngX * 50f * Time.deltaTime, 0);
            }
            transform.Rotate(chngY * 50f * Time.deltaTime, 0, 0);
        }

    }


    void StartUpAnimation() {
         // Start up animations
        if (transform.localScale.x <= 1.5 && transform.localScale.y <= 1.5 && transform.localScale.z <= 1.5) {
            // Scale the image big from 0 to 1.5 and rotate while scaling
            transform.localScale += scaleChange;
            transform.Rotate(0.0f, 0.0f, 1.0f); 
        } else {
            sizeDone = true;
        }
        if (sizeDone && !doneAll) {
            // if image is not up right rotate till it is
            if (Mathf.Round(transform.eulerAngles.z) != 90) {
                transform.Rotate(0.0f, 0.0f, 1.0f);
            } else {
                doneAll = true;
            }
        }
    }
}
