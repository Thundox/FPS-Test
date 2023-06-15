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
    public GameObject CoreToRotate;

    private void Start()
    {
        timeLeft = timeToShoot;
    }
    private void OnTriggerEnter(Collider other) // Player enters targeting range, begin targeting.
    {
        if(other.tag == "Player")
        {
            PlayerPosition = other.transform.position;
            MyState = 1; // Set State to Target
        }
    }

    private void OnTriggerExit(Collider other) // Player leaves range go back to idle
    {
        if(other.tag == "Player")
        {
            PlayerToShoot = other.gameObject;
            PlayerPosition = new Vector3(0,0,0);
            MyState = 0; // Set state to Idle
            timeLeft = timeToShoot;
        }
    }


    private void Update()
    {
        if(MyState == 0) // Idle
        {
            MyLineRenderer.enabled= false;
        }
        if(MyState == 1) // Targeting
        {
            if (countDown)
            {
                timeLeft -= Time.deltaTime;
                if(timeLeft <= 0)
                {
                    MyState = 2;
                    timeLeft = timeToShoot;
                }
            }
                MyLineRenderer.enabled= true;

            Vector3 direction = PlayerToShoot.transform.position - CoreToRotate.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            if (CoreToRotate != null)
            {
                CoreToRotate.transform.rotation = Quaternion.RotateTowards(CoreToRotate.transform.rotation, targetRotation, turnRate * Time.deltaTime);
            }
            else
                CoreToRotate.transform.rotation = Quaternion.RotateTowards(CoreToRotate.transform.rotation, targetRotation, turnRate * Time.deltaTime);

        }
        if(MyState == 2) // Shoot
        {

            GameObject newObject = Instantiate(DamageObject, transform.position, CoreToRotate.transform.rotation);
            // put shoot function here.
            MyState = 1; // Set to Target
        }
    }

    

}
