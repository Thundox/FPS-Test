using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;
    public int damage = 1;
    public float speed = 10;
    Rigidbody rb;
    Vector3 Velocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Velocity = transform.forward * speed;
        StartCoroutine(DestroyAfterTime());
    }
    private void Update()
    {
        Velocity = transform.forward * speed;
        rb.velocity = Velocity;
    }
   
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().ChangeHealth(-damage);
            Destroy(gameObject);
        }
    }
}
