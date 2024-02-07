using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItemController : MonoBehaviour
{
    public TextMeshProUGUI itemPriceObj;
    public GameObject shopItem;
    public GameObject inventoryItem;
    private string itemPriceStr;
    private int itemPrice;

    void Start()
    {
        itemPriceStr = itemPriceObj.text.ToString();
        int.TryParse(itemPriceStr, out itemPrice);
    }

    public void Buy()
    {
        if (itemPrice <= EventsManager.currentPlayerStars) 
        {
            EventsManager.currentPlayerStars -= itemPrice;
            PlayerPrefs.SetInt("Stars", EventsManager.currentPlayerStars);
            shopItem.SetActive(false);
            inventoryItem.SetActive(true);
        }
    }
}
