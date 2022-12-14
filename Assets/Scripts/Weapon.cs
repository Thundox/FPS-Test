using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Weapon settings
    public int Ammo;
    public int SpareAmmo;
    public int ClipSize;
    public int Damage;
    public float DelayBetweenShots;
    private bool IsReloading = false;
    public int Range;
    public float ReloadTime;
    private bool CanShoot;
    public bool IsAutomatic;
    public bool IsHeld;
    // Recoil settings
    public float RecoilVertical;
    public float RecoilDuration;
    public LayerMask MyLayerMask;
    

    // Start is called before the first frame update
    void Start()
    {
        CanShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    bool CheckInput()
    {
        if (IsAutomatic == true)
        {
           return Input.GetMouseButton(0);
        }
        if (IsAutomatic == false)
        {
            return Input.GetMouseButtonDown(0);
        }
            return false;
    }
    public float Shoot(Transform MyHead)
    {
        // Check to see if we CAN shoot.
        if (CheckInput() && Ammo > 0 && IsReloading == false && CanShoot == true ) 
        {
            Ammo = Ammo - 1;
            Debug.Log("Left Click Pressed");
            Debug.DrawRay(MyHead.position, MyHead.forward * Range, Color.red, 5);
            RaycastHit HitData;
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            StartCoroutine(DelayShot() );
            //Check to see if we hit an enemy
           if (Physics.Raycast(ray, out HitData, Range, MyLayerMask))
            {
                ResolveHittingEnemy(HitData, Damage);
            }
            return RecoilVertical;
        }
        return 0;
    }
    

    public IEnumerator Reload()
    {
        if (!IsReloading && Ammo < ClipSize )
        {
            IsReloading = true;
            yield return new WaitForSeconds(ReloadTime);
            Debug.Log("Finished Waiting");
            Ammo = ClipSize;
            IsReloading = false;
        }
    }

    IEnumerator DelayShot()
    {
        CanShoot = false;
        yield return new WaitForSeconds (DelayBetweenShots);
        CanShoot = true;
    }

    void ResolveHittingEnemy(RaycastHit HitData, int Damage)
    {
        if (HitData.transform.tag == "Enemy")
        {
            if (HitData.transform.GetComponent <Enemy>().IsEnemyDead(Damage))
            {
                HitData.transform.gameObject.SetActive(false);
            }
            
        }
    }
}
