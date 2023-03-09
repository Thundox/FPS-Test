using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    //Recoil
    public float RecoilSpeed;
    public float MinimumRecoilPercent;
    public float CurrentRecoil;
    public float RecoilRecoverPerSecond = 10;
    public float TotalRecoilRecoveryPercent = -0.5f; // Must Be a negative number.    
    private float LastShotRecoil;
    private float RecoilLeftToRecover;
    private float RecoilLeftToApply;
    private float MinimumRecoil;

    public Vector3 MyVelocity;
    private Transform playerTransform;

    // Boost Variables
    public float BoostStrength;
    public int BoostCharges;
    public float BoostRechargeTime;

    // Old
    //public float maxSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        RB = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        IceSkatingMovement();
        //Movement();
    }
    // Update is called once per frame
    void Update()
    {
        MyVelocity = RB.velocity;
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
        Boost();
    }

    public float GetRotateVerticle()
    {
        return RotateVertical;
    }
  
    //void Movement()
    //{

    //    RB.velocity = Vector3.ClampMagnitude(RB.velocity, maxSpeed);

    //    RB.AddForce(transform.forward * Speed);
    //    //Forward and back movement

    //    RB.MovePosition(transform.position + (transform.forward * MovementVertical * Speed * Time.deltaTime) +
    //     //Left and Right movement
    //     (transform.right * MovementHorizontal * Speed * Time.deltaTime));
    //}
    // Change to Ienumerator?

    void IceSkatingMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, RB.velocity.y, vertical);
        direction = playerTransform.TransformDirection(direction);

        RB.AddForce(transform.forward * vertical * Speed, ForceMode.Force);
        RB.AddForce(transform.right * horizontal * Speed, ForceMode.Force);
    }

    void Boost()
    {
        if (Input.GetKeyDown (KeyCode.E) && BoostCharges > 0)
        {
           BoostCharges = BoostCharges - 1;
           Debug.Log("e is pressed");
           var LocalVelocity = transform.InverseTransformDirection(RB.velocity);
           if (LocalVelocity.x < -BoostStrength)
            {
                LocalVelocity.x = LocalVelocity.x * -1;
                RB.velocity = transform.TransformDirection(LocalVelocity);

            }
           else if (LocalVelocity.x > -BoostStrength && LocalVelocity.x < 0)
            {
                LocalVelocity.x = BoostStrength;
                RB.velocity = transform.TransformDirection(LocalVelocity);
            }
            else
            {
                RB.AddForce(transform.right * BoostStrength, ForceMode.Impulse);
            }
            if (BoostCharges < 1)
            {
                StartCoroutine(BoostRecharge()); 
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && BoostCharges > 0)
        {
            BoostCharges = BoostCharges - 1;
            Debug.Log("Q is pressed");
            var LocalVelocity = transform.InverseTransformDirection(RB.velocity);
            if (LocalVelocity.x < -BoostStrength)
            {
                LocalVelocity.x = LocalVelocity.x * +1;
                RB.velocity = transform.TransformDirection(LocalVelocity);

            }
            else if (LocalVelocity.x > -BoostStrength && LocalVelocity.x < 0)
            {
                LocalVelocity.x = BoostStrength;
                RB.velocity = transform.TransformDirection(LocalVelocity);
            }
            else
            {
                RB.AddForce(transform.right * -BoostStrength, ForceMode.Impulse);
            }
            if (BoostCharges < 1)
            {
                StartCoroutine(BoostRecharge());
            }
        }

    }

    public IEnumerator BoostRecharge()
    {      
            yield return new WaitForSeconds(BoostRechargeTime);
        if (BoostCharges <= 0)
        {
            Debug.Log("Boosts before recharge: " + BoostCharges);
            BoostCharges = BoostCharges +1;
            Debug.Log("Boosts after recharge: " + BoostCharges);
        }
            
            
    }

    public void ApplyRecoil(float Recoil)
    {
        if(Recoil > 0)
        {
            CurrentRecoil = Recoil;
            MinimumRecoil = CurrentRecoil * MinimumRecoilPercent;
            Debug.Log("RecoilSet");
            LastShotRecoil = Recoil;
            RecoilLeftToRecover = LastShotRecoil * TotalRecoilRecoveryPercent;
            RecoilLeftToApply = Recoil;
        }
        
        //Downwards recoil recovery.
        if (CurrentRecoil < MinimumRecoil)          
        {
            RecoilLeftToApply = 0;
            CurrentRecoil = 0;
            RecoilLeftToRecover -= RecoilRecoverPerSecond * RecoilSpeed * Time.deltaTime;
            //return;
            if (RecoilLeftToRecover <= 0)
            {
                
                RecoilLeftToRecover = 0;
                CurrentRecoil = 0;
                return;
            }
            RotateVertical += RecoilRecoverPerSecond * RecoilSpeed * Time.deltaTime;
 
        }

        //Upwards Recoil
        else if(RecoilLeftToApply > 0)
        {
            Debug.Log("Recoil Applied");
            RecoilLeftToApply -= CurrentRecoil * RecoilSpeed * Time.deltaTime;
            RotateVertical -= CurrentRecoil * RecoilSpeed * Time.deltaTime;
            CurrentRecoil -= CurrentRecoil * RecoilSpeed * Time.deltaTime;
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
