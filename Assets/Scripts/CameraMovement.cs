using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    bool creativeMode;      //Enables camera movements or player movements
    private float speed;     //Camera movement speed
    private float yaw;      
    private float pitch;

    void Start() {
        creativeMode = true;
        speed = 5.0f;
        yaw = 0.0f;
        pitch = 0.0f;
    }


    void Update() {
        if (creativeMode) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                speed = 10.0f;      //Increases speed when Left Shift is held
            }
            else {
                speed = 5.0f;
            }

            if (Input.GetKey(KeyCode.W)) {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.A)) {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.S)) {
                transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }

            if (Input.GetMouseButton(1)) {
                yaw += 2.0f * Input.GetAxis("Mouse X");
                pitch -= 2.0f * Input.GetAxis("Mouse Y");
                transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            }
        }
    }
}
