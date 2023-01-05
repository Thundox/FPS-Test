using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Handles Walking and camera movement.
    public GameObject PlayerGameObject;
    public GameObject Head;
    public float Sensitivity;
    public float Speed;
    public float JumpHeight;
    private Rigidbody RB;
    private bool IsGrounded = false;
    float MovementHorizontal = 0;
    float MovementVertical = 0;
    private float RotateVertical = 0;


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
        //RotateVertical = Input.GetAxis("Mouse Y");
        MovementHorizontal = Input.GetAxis("Horizontal");
        MovementVertical = Input.GetAxis("Vertical");

        // Camera left and right movement
        transform.RotateAround(PlayerGameObject.transform.position, Vector3.up, RotateHorizontal * Sensitivity);
        // Camera up and down movement
        //Head.transform.RotateAround(Head.transform.position, -transform.right, RotateVertical * Sensitivity);
        RotateVertical += Input.GetAxis("Mouse Y") * -Sensitivity;
        RotateVertical = Mathf.Clamp(RotateVertical, -90, 90);
        Head.transform.localRotation = Quaternion.Euler(RotateVertical, Head.transform.rotation.y, 0);

        Jump();
    }

    public float GetRotateVerticle()
    {
        return RotateVertical;
    }
  
    void Movement()
    {
            //RB.AddForce(transform.forward * Speed);
            // Forward and back movement
            RB.MovePosition(transform.position + (transform.forward * MovementVertical * Speed * Time.deltaTime) +
                // Left and Right movement
                                                 (transform.right * MovementHorizontal * Speed * Time.deltaTime));
    }
    public void ApplyRecoil(float Recoil)
    {
        RotateVertical -= Recoil;
        Recoil = 0;
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
