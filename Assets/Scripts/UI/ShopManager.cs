using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopItem;
    public TextMeshProUGUI playerStars;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerStars.text = EventsManager.currentPlayerStars.ToString("");
    }

    public void Buy()
    {
        //Get Item price
        //Verify player stars balance
        //subtract stars from total
        //move item from shop to inventory 
    }
}
