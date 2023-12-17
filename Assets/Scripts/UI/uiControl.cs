using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class uiControl : MonoBehaviour
{
    
    public static int starCount;
    public static int heartCount;
    public static int ammoCount=5;
    public TextMeshProUGUI starCountDisplay;
    public TextMeshProUGUI heartCountDisplay;
    public TextMeshProUGUI ammoCountDisplay;
    public TextMeshProUGUI heartCountContinueDisplay;
    public TextMeshProUGUI pointsCountDisplay;
    public Transform playerPos;
    public static int points;
    public static int score;
    void Update()
    {
        points = (int)(playerPos.position.z / 10);
        score = starCount * 5 + points;
        starCountDisplay.text = "" + starCount;
        heartCountDisplay.text = "" + heartCount;
        ammoCountDisplay.text = "" + ammoCount;
        heartCountContinueDisplay.text = "" + heartCount;
        pointsCountDisplay.text = "" + score;
    }
}
