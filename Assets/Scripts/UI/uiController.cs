using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class uiController : MonoBehaviour
{
    
    public static int starCount;
    public static int heartCount;
    public static int ammoCount=15;
    public TextMeshProUGUI starCountDisplay;
    public TextMeshProUGUI heartCountDisplay;
    public TextMeshProUGUI ammoCountDisplay;
    public TextMeshProUGUI heartCountContinueDisplay;
    public TextMeshProUGUI pointsCountDisplay;
    public TextMeshProUGUI recordDisplay;
    public GameObject NewRecordPopUp;
    public Transform playerPos;

    public static int points;
    public static int score;
    private int record;
    void Update()
    {
        record = PlayerPrefs.GetInt("bestScore");
        points = (int)(playerPos.position.z / 10);
        score = starCount * 5 + points;
        recordDisplay.text = "" + record;
        starCountDisplay.text = "" + starCount;
        heartCountDisplay.text = "" + heartCount;
        ammoCountDisplay.text = "" + ammoCount;
        heartCountContinueDisplay.text = "" + heartCount;
        pointsCountDisplay.text = "" + score;

        if (score >= record)
        {
            if (record > 0)
                NewRecordPopUp.SetActive(true);
            recordDisplay.text = "" + score;

        }

    }
}
