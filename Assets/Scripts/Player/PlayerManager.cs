using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject continuePanel;
    public GameObject livesCount;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;

            if (CollectibleControl.heartCount == 0)
            {
                GameOver();
            }
            else if (CollectibleControl.heartCount > 0 && !continuePanel.activeSelf)
            {
                
                ShowContinuePanel();
            }
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    void ShowContinuePanel()
    {
        continuePanel.SetActive(true);
       
    }
}
