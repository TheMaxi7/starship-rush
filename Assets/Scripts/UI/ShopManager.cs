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

    void Update()
    {

        currentPlayerStars = PlayerPrefs.GetInt("Stars");
        playerStars.text = currentPlayerStars.ToString("");
    }
}
