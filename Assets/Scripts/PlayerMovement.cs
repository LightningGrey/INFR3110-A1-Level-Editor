using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;        //Player movement speed
    private float jumpForce = 5.0f;
    CameraMovement camMovement; //Reference for CameraMovement script
    Rigidbody rb;               //Reference for Rigidbody
    private bool isGrounded;

    void Start()
    {
        camMovement = Camera.main.GetComponent<CameraMovement>(); //Referencing script in main camera
        rb = this.GetComponent<Rigidbody>();

    }

    void OnCollisionStay() {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!camMovement.creativeMode) {
            rb.useGravity = true;
            if (Input.GetKey(KeyCode.LeftShift)) {
                speed = 10.0f;      //Increases speed when Left Shift is held
            }
            else {
                speed = 5.0f;
            }

            if (Input.GetKey(KeyCode.W)) {
                transform.Translate(new Vector3(0.0f, 0.0f, speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.A)) {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f));
            }
            if (Input.GetKey(KeyCode.S)) {
                transform.Translate(new Vector3(0.0f, 0.0f, -speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0.0f, 0.0f));
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        else {
            rb.useGravity = false;
            rb.velocity = new Vector3(0.0f,0.0f,0.0f);
        }
    }
}
