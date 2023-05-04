using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Manager : MonoBehaviour
{
    public int Coins;
    public Text CoinsGUI;
    public MovingDoor Door1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoinCollected()
    {
        Coins = Coins + 1;
        CoinsGUI.text = Coins.ToString();
        if (Coins >= Door1.CoinsToOpen)
        {
            Door1.OpenDoor();
        }

        
    }
}
