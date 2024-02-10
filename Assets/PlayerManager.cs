using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] playerSkins;
    private string activeSkin;
    void Start()
    {
        activeSkin = PlayerPrefs.GetString("ActiveSkin");
        foreach (GameObject playerSkin in playerSkins)
        {
            if (playerSkin.name == activeSkin)
            {
                playerSkin.SetActive(true);
            }
        }
    }
    void Update()
    {
        
    }
}
