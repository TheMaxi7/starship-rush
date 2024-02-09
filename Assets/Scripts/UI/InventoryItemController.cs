using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public GameObject inventoryItem;
    public GameObject activeText;
    public GameObject setActiveButton;
    private string objName;
    public static string oldSkin;
    void Start()
    {
        objName = inventoryItem.name;

        if (PlayerPrefs.GetInt(objName) == 0)
            inventoryItem.SetActive(false);
        else
        {
            inventoryItem.SetActive(true);
            if (PlayerPrefs.GetString("ActiveSkin") == objName)
            {
                setActiveButton.SetActive(false);
                activeText.SetActive(true);

            }
            else
            {
                setActiveButton.SetActive(true);
                activeText.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt(objName) == 0)
            inventoryItem.SetActive(false);
        else
        {
            inventoryItem.SetActive(true);
            if (PlayerPrefs.GetString("ActiveSkin") == objName)
            {
                setActiveButton.SetActive(false);
                activeText.SetActive(true);

            }
            else
            {
                setActiveButton.SetActive(true);
                activeText.SetActive(false);
            }
        }
    }
    public void SetActiveSkin()
    {
        PlayerPrefs.SetString("ActiveSkin", objName);

    }
}
