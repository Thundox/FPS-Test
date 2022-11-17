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
    float MovementHorizontal = 0;
    float MovementVertical = 0;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Movement();



    }
    // Update is called once per frame
    void Update()
    {
        float RotateHorizontal = Input.GetAxis("Mouse X");
        float RotateVertical = Input.GetAxis("Mouse Y");
        MovementHorizontal = Input.GetAxis("Horizontal");
        MovementVertical = Input.GetAxis("Vertical");

        // Camera left and right movement
        transform.RotateAround(PlayerGameObject.transform.position, Vector3.up, RotateHorizontal * Sensitivity);
        // Camera up and down movement
        Head.transform.RotateAround(Head.transform.position, -transform.right, RotateVertical * Sensitivity);

        
        Jump();
    }

    void Movement()
    {
        
        
            //RB.AddForce(transform.forward * Speed);
            // Forward and back movement
            RB.MovePosition(transform.position + (transform.forward * MovementVertical * Speed * Time.deltaTime) +
                // Left and Right movement
                                                 (transform.right * MovementHorizontal * Speed * Time.deltaTime));

        

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
