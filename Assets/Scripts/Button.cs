using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Elevator MyElevator;
    private void OnTriggerEnter(Collider other)
    {
        MyElevator.TurnElevatorOn();
    }
}
