using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int BoostRechargeAmount = 1;
    public bool DoesRespawn;
    public int RespawnTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().BoostCharges += BoostRechargeAmount;
            if (DoesRespawn == false)
            {
                this.transform.GetChild(0).gameObject.SetActive(false);
                return;
            }
            if (DoesRespawn == true)
            {
                StartCoroutine (PowerUpRespawn());
                this.transform.GetChild(0).gameObject.SetActive(false);
            }
            
        }
    }

    public IEnumerator PowerUpRespawn()
    {

        Debug.Log(this.name + " Has started respawn time " + RespawnTime);
        yield return new WaitForSeconds(RespawnTime);
        Debug.Log(this.name + " Has Respawned");
        this.transform.GetChild(0).gameObject.SetActive(true);

    }

}
