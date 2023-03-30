using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 10;
    Rigidbody rb;
    Vector3 Velocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Velocity = transform.forward * speed;
    }
    private void Update()
    {
        Velocity = transform.forward * speed;
        rb.velocity = Velocity;
    }
}
