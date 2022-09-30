using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panoCamController : MonoBehaviour
{
    public static panoCamController Singleton;

    Vector3 rot = new Vector3();
    float horizontal;
    float vertical;
    public float sensitivity;
    public bool disabled;
    void Start() {
        Singleton = this;
    }


    public void LateUpdate() {
        //Detect Left mouse button
        if(Input.GetMouseButton(0) && !disabled) {
            //Read mouse input
            horizontal = Input.GetAxis("Mouse X");
            vertical= Input.GetAxis("Mouse Y");

            //Add to rotation Vector
            rot.x += vertical * Time.deltaTime * sensitivity;
            rot.y += -horizontal * Time.deltaTime * sensitivity;

            //Stop from flipping on its side
            rot.z = 0;

            //Stop from going upside down
            rot.x = Mathf.Clamp(rot.x, -80, 80);

            //Apply Changes
            transform.rotation = Quaternion.Euler(rot);
        }else{
            //Unlock the cursor once they stop clicking
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
