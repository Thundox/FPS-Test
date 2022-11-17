using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Ammo;
    public int SpareAmmo;
    public int ClipSize;
    public int Damage;
    public float DelayBetweenShots;
    private bool IsReloading = false;
    public int Range;
    public Transform MyHead;
    public float ReloadTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        if (Input.GetKeyDown(KeyCode.R))
        {

            StartCoroutine(Reload());
        }
    }
    

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Ammo > 0 && IsReloading == false ) 
        {
            Ammo = Ammo - 1;
            Debug.Log("Left Click Pressed");
            Debug.DrawRay(MyHead.position, MyHead.forward * Range, Color.red, 5);
            RaycastHit HitData;
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            

            if (Physics.Raycast(ray, out HitData, Range))
            {
                
                ResolveHittingEnemy(HitData, Damage);
            }
            
        }
    }

    IEnumerator Reload()
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
