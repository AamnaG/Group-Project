using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    // Variables for mouse controls
    public float mouseSensitivity = 500f;
    private float mouseRotation = 0f;
    //

    public float moveValue;
    public float rotateValue;
    public float moveSpeed;
    public float rotateSpeed;
    
    public Rigidbody rb;

    public bool isGrounded;
    public float jumpForce;
    public float gravityScale = 5;

    public float reboundForce;

    private Vector3 direction;

    public GameObject optionsMenu;

    public ParticleSystem dust;

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>().y;
        rotateValue = value.Get<Vector2>().x;
    }

    void OnJump(InputValue value)
    {
        Jump();
    }

    // No InputValue parameter, so makes the Jump() reusable
    void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
            GetComponent<Rigidbody>().AddForce(jump, ForceMode.Impulse);

            if (dust != null)
            {
                dust.Play();
            }
        }
    }

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Jump related
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy!!");
            //Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad*(90 - transform.eulerAngles.z)), Mathf.Sin(Mathf.Deg2Rad*(90 - transform.eulerAngles.z)), Mathf.Sin(Mathf.Deg2Rad*(90 - transform.eulerAngles.y))) * -1;
            //GetComponent<Rigidbody>().AddForce(direction * reboundForce, ForceMode.Impulse);

            //Vector3 movement = moveValue * -Vector3.forward;
            rb.AddForce(moveValue * Vector3.forward * reboundForce, ForceMode.Impulse);
            Debug.Log("Rebounded!");
            //transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
        }

        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Debug.Log("Killing Enemy!");
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    void Update()
    {
        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player object based on the mouse input
        transform.Rotate(Vector3.up * mouseX);

        // Calculate the rotation for the camera up and down
        mouseRotation -= mouseY;
        mouseRotation = Mathf.Clamp(mouseRotation, -90f, 90f);

        // Apply the rotation to the player's camera
        Camera.main.transform.localRotation = Quaternion.Euler(mouseRotation, 0f, 0f);

        // opens the options menu if the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleOptionsMenu();
        }
    }
    
    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass); // simulates gravity scale to make jump less 'floaty'

        Vector3 movement = moveValue * Vector3.forward;


        /*if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }*/

        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(rotateValue * rotateSpeed * Vector3.up * Time.fixedDeltaTime);

        //jump
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
            GetComponent<Rigidbody>().AddForce(jump, ForceMode.Impulse);
            isGrounded = false;
        }*/
            
    }

    void ToggleOptionsMenu()
    {
        // toggles the visibility of the options menu if its on/off
        optionsMenu.SetActive(!optionsMenu.activeSelf);

        // toggles the cursor lock based on the menu visibility
        UnityEngine.Cursor.lockState = optionsMenu.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
        UnityEngine.Cursor.visible = optionsMenu.activeSelf;
    }

 
}
