using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject continuePanel;
    public GameObject crosshairPanel;
    public GameObject livesCount;
    public ParticleSystem explosionParticle;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (gameOver)
        {

            if (uiControl.heartCount == 0)
            {
                GameOver();
            }
            else if (uiControl.heartCount > 0 && !continuePanel.activeSelf)
            {
                
                ShowContinuePanel();
            }
        }
    }

    void GameOver()
    {   
        gameOverPanel.SetActive(true);
        crosshairPanel.SetActive(false);
        PlayerShooting.canShoot = false;
        Cursor.visible = true;
        gameOver = true;
    }

    void ShowContinuePanel()
    {
        continuePanel.SetActive(true);
        crosshairPanel.SetActive(false);
        PlayerShooting.canShoot = false;
        Cursor.visible = true;
        gameOver = true;
    }



}
