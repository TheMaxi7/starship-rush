using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public GameObject inventoryItem;
    public GameObject activeText;
    private string objName;
    void Start()
    {
        objName = inventoryItem.name;
        if (PlayerPrefs.GetInt(objName) == 0)    
            inventoryItem.SetActive(false);
        else 
            inventoryItem.SetActive(true);

    }
    public void SetActive()
    {
        PlayerPrefs.SetString("ActiveSkin", objName);
        activeText.SetActive(true);
    }
}
