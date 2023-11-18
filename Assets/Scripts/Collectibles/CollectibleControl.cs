using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleControl : MonoBehaviour
{
    public static int starCount;
    public static int heartCount;
    public static int ammoCount;
    public TextMeshProUGUI starCountDisplay;
    public TextMeshProUGUI heartCountDisplay;
    public TextMeshProUGUI ammoCountDisplay;
    public TextMeshProUGUI heartCountContinueDisplay;


    void Update()
    {
        starCountDisplay.text =""+ starCount;
        heartCountDisplay.text = "" + heartCount;
        ammoCountDisplay.text = "" + ammoCount;
        heartCountContinueDisplay.text = "" + heartCount;
    }
}
