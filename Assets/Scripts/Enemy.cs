using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsEnemyDead (int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Debug.Log("Enemy Died");
            return true;
            
        }
        else
        {
            return false;
        }
    }
}
