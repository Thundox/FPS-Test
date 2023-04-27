using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour
{

    public float DoorTime;
    public float DoorSpeed;
    public Transform DoorDestination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, DoorDestination.position, DoorSpeed * Time.deltaTime);
    }
}
