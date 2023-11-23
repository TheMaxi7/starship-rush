using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class uiControl : MonoBehaviour
{
    
    public static int starCount;
    public static int heartCount;
    public static int ammoCount;
    public TextMeshProUGUI starCountDisplay;
    public TextMeshProUGUI heartCountDisplay;
    public TextMeshProUGUI ammoCountDisplay;
    public TextMeshProUGUI heartCountContinueDisplay;
    public TextMeshProUGUI pointsCountDisplay;
    public Transform playerPos;
    public static int points;
    void Update()
    {
        points = (int)(playerPos.position.z / 10);
        starCountDisplay.text = "" + starCount;
        heartCountDisplay.text = "" + heartCount;
        ammoCountDisplay.text = "" + ammoCount;
        heartCountContinueDisplay.text = "" + heartCount;
        pointsCountDisplay.text = "" + points;
    }
}
