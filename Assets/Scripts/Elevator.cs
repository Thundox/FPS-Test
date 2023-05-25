using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool On = false;
    public Animator MyAnimator;
    
    public void TurnElevatorOn()
    {
        On = true;
        MyAnimator.SetBool("On", true);
    }
}
