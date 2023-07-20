using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class UI_Manager : MonoBehaviour
{
    public Text HealthText; // Only update health when health changes
    public Text AmmoText; // Update Ammo after shooting or changing weapons
    public Text BoostText; // Update when gain or use a boost including recharge
    public WeaponHandler MyWeaponHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetHealth(int Health)
    {
        HealthText.text = "Health " + Health.ToString();
    }
    public void SetAmmo(int Ammo)
    {
        AmmoText.text = "Ammo " + Ammo.ToString();
        if (MyWeaponHandler.PlayerWeapon == null)
        {
            AmmoText.text = "Ammo 0";
        }
    }
    public void SetBoost(int Boost)
    {
        BoostText.text = "Boosts " + Boost.ToString();
    }

}
