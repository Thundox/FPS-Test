using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool On = false;
    public Animator MyAnimator;
    private Rigidbody playerRigidbody;
    private Vector3 playerVelocity;
    private bool PlayerIsStanding = false;

    public void TurnElevatorOn()
    {
        On = true;
        MyAnimator.SetBool("On", true);
    }
    private void Start()
    {
        playerRigidbody= GetComponent<Rigidbody>();
        MyAnimator.updateMode = AnimatorUpdateMode.AnimatePhysics;
    }
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "Player")
        //{            // Store the player's velocity before the collision
        //    PlayerIsStanding = true;
        //    playerRigidbody = other.gameObject.GetComponent<Rigidbody>();
        //    playerVelocity = playerRigidbody.velocity;

        //    // Set the player as a child of the animated object
        //    other.transform.parent = transform;

        //    // Restore the player's velocity after setting it as a child
        //    playerRigidbody.velocity = playerVelocity;

        //}

        
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    other.transform.parent = null;
        //}
    }
}
