using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopItemController : MonoBehaviour
{
    public TextMeshProUGUI itemPriceObj;
    public GameObject shopItem;
    public GameObject inventoryItem;
    public GameObject activeSkinText;
    private string itemPriceStr;
    private int itemPrice;
    private string objName;
    void Start()
    {

        itemPriceStr = itemPriceObj.text.ToString();
        int.TryParse(itemPriceStr, out itemPrice);
        objName = shopItem.name;
        if (PlayerPrefs.GetInt(objName) == 1)    
            shopItem.SetActive(false);
        else 
            shopItem.SetActive(true);

    }

    public void Buy()
    {
        if (itemPrice <= ShopManager.currentPlayerStars) 
        {
            ShopManager.currentPlayerStars -= itemPrice;
            PlayerPrefs.SetInt("Stars", ShopManager.currentPlayerStars);
            shopItem.SetActive(false);
            inventoryItem.SetActive(true);
            //activeSkinText.SetActive(true);
            PlayerPrefs.SetInt(objName, 1);
            PlayerPrefs.SetString("ActiveSkin", objName);

        }
    }
}
