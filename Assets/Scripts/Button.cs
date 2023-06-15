using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Elevator MyElevator;
    public Animator MyAnimator;
    private void OnTriggerEnter(Collider other)
    {
        MyElevator.TurnElevatorOn();
        MyAnimator.SetTrigger("ButtonPressed");
    }
}
