using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {

    Animator animator;
    Vector3 prevPos = Vector3.zero;
    Vector3 posDelta = Vector3.zero;
    Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    Vector3 moveChange = new Vector3(0.0f, -0.01f, 0.0f);
    bool sizeDone = false;
    bool doneAll = false;

    void Start() {
        animator = GetComponent<Animator>(); 
    }
    // Update is called once per frame
    void Update() {

        
        if (transform.localScale.x <= 1.5 && transform.localScale.y <= 1.5 && transform.localScale.z <= 1.5) {
            transform.localScale += scaleChange;
            transform.Rotate(0.0f, 0.0f, 1.0f);
        } else {
            sizeDone = true;
        }
        if (sizeDone && !doneAll) {
            if (Mathf.Round(transform.eulerAngles.z) != 90) {
                transform.Rotate(0.0f, 0.0f, 1.0f);
            } else {
                doneAll = true;
            }
        } 

        // if (doneAll) {
        //     if (Input.GetMouseButton(0)) {
                
        //         posDelta = Input.mousePosition - prevPos;
        //         if (Vector3.Dot(transform.up, Vector3.up) >= 0) {
        //             transform.Rotate(transform.up, -Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);

        //         } else {
        //             transform.Rotate(transform.up, Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);
        //         }
        //         transform.Rotate(Camera.main.transform.right, Vector3.Dot(posDelta, Camera.main.transform.up), Space.World);
        //     }

        //     prevPos = Input.mousePosition;
        // }
        

        
    }
    bool AnimatorIsPlaying(){
     return animator.GetCurrentAnimatorStateInfo(0).length >
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
  }
}
