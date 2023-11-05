using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


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

    private Vector3 direction;

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>().y;
        rotateValue = value.Get<Vector2>().x;
    }

    void OnJump(InputValue value)
    {
        if (isGrounded)
        {
            isGrounded = false;
            Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
            GetComponent<Rigidbody>().AddForce(jump, ForceMode.Impulse);
        }
    }

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Jump related
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
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

 
}
