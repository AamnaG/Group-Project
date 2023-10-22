using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Jump related
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {

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
