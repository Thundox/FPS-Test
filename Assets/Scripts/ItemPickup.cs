using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public WeaponHandler PlayerWeaponHandler;
    // Start is called before the first frame update
    void Start()
    {
       if(transform.parent.TryGetComponent(out WeaponHandler mycomponent))
        {
            PlayerWeaponHandler = mycomponent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Item Pickup Script
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon"))
        {
            if(PlayerWeaponHandler.PlayerWeapon == null)
            {
                
                other.transform.parent = PlayerWeaponHandler.MyHand;
                other.transform.localPosition = Vector3.zero;
                other.transform.localRotation = Quaternion.identity;
                PlayerWeaponHandler.PlayerWeapon = other.GetComponent<Weapon>();
                PlayerWeaponHandler.MyGunTransform = other.transform;

                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<BoxCollider>().enabled = false;

                other.gameObject.layer = 9;
            }
        }
    }
}
