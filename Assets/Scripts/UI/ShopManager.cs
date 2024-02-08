using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopItem;
    public TextMeshProUGUI playerStars;
    public static int currentPlayerStars;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentPlayerStars = PlayerPrefs.GetInt("Stars");
        playerStars.text = currentPlayerStars.ToString("");
    }

    public void Buy()
    {
        //Get Item price
        //Verify player stars balance
        //subtract stars from total
        //move item from shop to inventory 
    }
}
