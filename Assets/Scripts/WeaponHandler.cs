using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    // Handles Inputs
    public Weapon PlayerWeapon;
    public Transform MyHead;
    public Transform MyHand;
    public float ThrowForce;
    public Transform MyGunTransform;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {        
        if (PlayerWeapon != null)
        {
           MyGunTransform = PlayerWeapon.transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        DropWeapon();
        if (PlayerWeapon != null)
        {
          playerMovement.ApplyRecoil(PlayerWeapon.Shoot(MyHead));
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(PlayerWeapon.Reload());
            }
        }
    }

    void DropWeapon()
    {
        if (PlayerWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                MyGunTransform.GetComponent<Rigidbody>().isKinematic = false;
                MyGunTransform.GetComponent<BoxCollider>().enabled = true;
                PlayerWeapon=null;
                MyGunTransform=null;
                // Broken need to change how player movement velocity works
                //MyHand.GetChild(0).GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
                MyHand.GetChild(0).GetComponent<Rigidbody>().AddForce(MyHead.transform.forward * ThrowForce,ForceMode.Impulse);
                MyHand.DetachChildren();

                
                
            }
        }
    }
}
