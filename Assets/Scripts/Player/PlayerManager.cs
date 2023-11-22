using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject continuePanel;
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
        Invoke("SetPause", 3f);
    }

    void ShowContinuePanel()
    {
        continuePanel.SetActive(true);
        Invoke("SetPause", 3f);
    }

    void SetPause()
    {
        Time.timeScale = 0;
    }

}
