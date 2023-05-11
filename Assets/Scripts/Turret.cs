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
    public float timeToShoot = 3;
    public GameObject PlayerToShoot;
    public bool countDown = true;


    private void Start()
    {
        timeLeft = timeToShoot;
    }
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
            PlayerToShoot = other.gameObject;
            PlayerPosition = new Vector3(0,0,0);
            MyState = 0; // Set state to Idle
            timeLeft = timeToShoot;
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
                    timeLeft = timeToShoot;
                }
            }
                MyLineRenderer.enabled= true;

            Vector3 direction = PlayerToShoot.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnRate * Time.deltaTime);
        }
        if(MyState == 2) // Shoot
        {

            GameObject newObject = Instantiate(DamageObject, transform.position, transform.rotation);
            // put shoot function here.
            MyState = 1; // Set to Target
        }
    }

    

}
