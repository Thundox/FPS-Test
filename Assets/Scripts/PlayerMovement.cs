using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Handles player movement and camera movement.
    public GameObject PlayerGameObject;
    public GameObject Head;
    private Rigidbody RB;
    public float Sensitivity;
    public float Speed;
    private float MovementHorizontal = 0;
    private float MovementVertical = 0;
    private float RotateVertical = 0;
    // Handles Jump behaviour
    public float JumpHeight;
    private bool IsGrounded = false;
    public float recoilFraction;
    public float MinimumRecoil;
    public float CurrentRecoil;

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
    // Change to Ienumerator?
    public void ApplyRecoil(float Recoil)
    {
        if(Recoil > 0)
        {
            CurrentRecoil = Recoil;
        }
        if (CurrentRecoil < MinimumRecoil)          
        {
            CurrentRecoil = 0;
            return;
        }
        Debug.Log("RecoilApplied");
        RotateVertical -= CurrentRecoil * recoilFraction;
        CurrentRecoil -= CurrentRecoil * recoilFraction;

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
