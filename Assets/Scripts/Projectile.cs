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
    public bool PlayerProjectile;
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
        if (PlayerProjectile == false)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PlayerHealth>().ChangeHealth(-damage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.tag == "Enemy")
            {
                if (other.GetComponent<Enemy>().DamageThenCheckEnemyDead(damage))
                {
                    other.transform.gameObject.SetActive(false);
                }
                Destroy(gameObject);
                
            }
        }
                
        
    }
}
