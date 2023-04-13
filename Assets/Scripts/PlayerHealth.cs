using System.Collections;
using System.Collections.Generic;
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

    private void ResolveTrap(Collision Trap)
    {
        Health -= Trap.gameObject.GetComponent<Trap>().Damage;
        if (Health <= 0)
        {
            Respawn();

        }
        Debug.Log("Health was reduced to: " + Health);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            ResolveTrap(collision);
        }
        
    }
}
