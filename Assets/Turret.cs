using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int MyState = 0; // 0 = Idle, 1 = Target Player, 2 = Shoot
    public int DelayBeforeShooting = 2;
    public float Counter = 0;
    public LineRenderer MyLineRenderer;
    public GameObject DamageObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MyState = 1; // Set State to Target
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            MyState = 0; // Set state to Idle
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Counter = Counter += Time.deltaTime;
        if(Counter >= DelayBeforeShooting) 
        {
            Counter = 0;
            MyState = 2; // Shoot
        }
    }

    private void Update()
    {
        if(MyState == 0) // Idle
        {
            MyLineRenderer.enabled= false;
        }
        if(MyState == 1) // Target
        {
            MyLineRenderer.enabled= true;
        }
        if(MyState == 2) // Shoot
        {
            GameObject newObject = Instantiate(DamageObject, transform.position, Quaternion.identity);
            // put shoot function here.
            MyState = 1; // Set to Target
        }
    }

}
