using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int MyState = 0; // 0 = Idle, 1 = Target Player, 2 = Shoot
    public int DelayBeforeShooting = 2;
    public float timeLeft = 3;
    public float turnRate = 5;
    public LineRenderer MyLineRenderer;
    public GameObject DamageObject;
    public Vector3 PlayerPosition;
    public bool countDown;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerPosition = other.transform.position;
            MyState = 1; // Set State to Target
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerPosition = new Vector3(0,0,0);
            MyState = 0; // Set state to Idle
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void Update()
    {
        if(MyState == 0) // Idle
        {
            MyLineRenderer.enabled= false;
        }
        if(MyState == 1) // Target
        {
            if (countDown)
            {
                timeLeft -= Time.deltaTime;
                if(timeLeft <= 0)
                {
                    MyState = 2;
                    timeLeft = 3;
                }
            }
                MyLineRenderer.enabled= true;
            Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(PlayerPosition), Time.deltaTime * turnRate);
        }
        if(MyState == 2) // Shoot
        {

            GameObject newObject = Instantiate(DamageObject, transform.position, transform.rotation);
            // put shoot function here.
            MyState = 1; // Set to Target
        }
    }

    

}
