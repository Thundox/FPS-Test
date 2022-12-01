using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Weapon PlayerWeapon;
    public Transform MyHead;
    public Transform MyHand;
    public Transform MyGunTransform;
    public float ThrowForce;


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
        DropWeaon();
        if (PlayerWeapon != null)
        {
            PlayerWeapon.Shoot(MyHead);
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(PlayerWeapon.Reload());
            }
        }
    }

    void DropWeaon()
    {
        if(PlayerWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                MyGunTransform.GetComponent<Rigidbody>().isKinematic = false;
                MyGunTransform.GetComponent<BoxCollider>().enabled = true;
                PlayerWeapon = null;
                MyGunTransform = null;
                MyHand.GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.forward * ThrowForce, ForceMode.Impulse);
                MyHand.DetachChildren();
                

            }
        }
        
    }
}
