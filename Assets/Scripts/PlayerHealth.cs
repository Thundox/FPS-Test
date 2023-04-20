using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    private int MaxHealth;
    public Vector3 RespawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = transform.position;
        MaxHealth = Health;
    }

    void Respawn()
    {
        transform.position = RespawnPoint;
        Health = MaxHealth;
    }

    public void ResolveDamage(Collision harmfulObject)
    {
        if(harmfulObject.gameObject.CompareTag("Trap"))
        {
            Health -= harmfulObject.gameObject.GetComponent<Trap>().Damage;
        }

        else if(harmfulObject.gameObject.CompareTag("Projectile"))
        {
            Health -= harmfulObject.gameObject.GetComponent<Projectile>().damage;
            Destroy(harmfulObject.gameObject);
        }
        if (Health <= 0)
        {
            Respawn();

        }
        Debug.Log("Health was reduced to: " + Health);
    }


    public void OnCollisionEnter(Collision collision)
    {
        ResolveDamage(collision);
        if (collision.gameObject.tag == "Trap")
        {
            ResolveDamage(collision);
        }
        
    }

}
