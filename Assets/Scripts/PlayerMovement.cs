using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject PlayerGameObject;
    public GameObject Head;
    public float Sensitivity;
    public float Speed;
    public float JumpHeight;
    private Rigidbody RB;
    private bool IsGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        

        
        
    }
    // Update is called once per frame
    void Update()
    {
        float RotateHorizontal = Input.GetAxis("Mouse X");
        float RotateVertical = Input.GetAxis("Mouse Y");
        // Camera left and right movement
        transform.RotateAround(PlayerGameObject.transform.position, Vector3.up, RotateHorizontal * Sensitivity);
        // Camera up and down movement
        Head.transform.RotateAround(Head.transform.position, -transform.right, RotateVertical * Sensitivity);
        Movement();
        Jump();
    }

    void Movement()
    {
        if( Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 )
        {
            //RB.AddForce(transform.forward * Speed);
            // Forward and back movement
            RB.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * Speed * Time.deltaTime) +
                // Left and Right movement
                                                 (transform.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime));

        }

    }

    void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space is pressed");
            if (IsGrounded == true)
            {
                RB.AddForce(transform.up * JumpHeight, ForceMode.Impulse);
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}
