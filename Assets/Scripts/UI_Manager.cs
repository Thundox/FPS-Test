using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class UI_Manager : MonoBehaviour
{
    public Text HealthText; // Only update health when health changes
    public Image MyHealthBar;
    public Text AmmoText; // Update Ammo after shooting or changing weapons
    public Text BoostText; // Update when gain or use a boost including recharge
    public WeaponHandler MyWeaponHandler;
    public Image MyBoostBar;
    

    // Start is called before the first frame update
    void Start()
    {
        MyBoostBar.fillAmount = 1;
    }
    public void SetBoostBarUI(float BarPercentage)
    {
        MyBoostBar.fillAmount = BarPercentage;
    }
    public void SetHealth(int Health)
    {
        HealthText.text = "Health " + Health.ToString();
        MyHealthBar.fillAmount = (float)Health / 100; // replace with max health later to enable health values above 100
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
