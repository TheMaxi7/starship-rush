using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject[] activeTexts;
    public GameObject[] setActiveButtons;

    public string activeSkin;
    public int skinIndex;
    private int oldSkinIndex;
    public static Dictionary<string, int> skinDic = new Dictionary<string, int>
        {
            {"Falcon", 1},
            {"Gladius", 2},
            {"Trident", 3},
            {"Valkyrie", 4},
            {"Excalibur", 5}
        };
    void Start()
    {
        
    }
    void Update()
    {
    }
    

}
