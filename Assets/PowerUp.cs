using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int BoostRechargeAmount = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().BoostCharges += 1;
            this.gameObject.SetActive(false);
        }
    }

}
