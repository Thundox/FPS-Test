using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingDoor : MonoBehaviour
{

    public float DoorTime;
    public float DoorSpeed;
    public Transform DoorDestination;
    public int CoinsToOpen;
    public bool DoorIsOpening;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DoorIsOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, DoorDestination.position, DoorSpeed * Time.deltaTime);
            if (transform.position == DoorDestination.position)
            {
                DoorIsOpening = false;
            }
        }
    }
    public void OpenDoor()
    {
        DoorIsOpening = true;
    }

}
