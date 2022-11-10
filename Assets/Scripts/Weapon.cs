using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Ammo;
    public int Damage;
    public float DelayBetweenShots;
    public int Range;
    public Transform MyHead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
