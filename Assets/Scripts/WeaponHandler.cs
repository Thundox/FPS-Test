using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Weapon PlayerWeapon;
    public Transform MyHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWeapon.Shoot(MyHead);
        if (Input.GetKeyDown(KeyCode.R))
        {

            StartCoroutine(PlayerWeapon.Reload());
        }
    }
}
