using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject continuePanel;
    public GameObject crosshairPanel;
    public GameObject pausePanel;
    public GameObject continueMenuFirst;
    public GameObject restartMenuFirst;
    public GameObject pauseMenuFirst;
    public AudioSource backGroundMusic;
    public GameObject gameUI;
    public GameObject countDownPanel;
    public GameObject settingsPanel;
    public TextMeshProUGUI bestScoreTextGameOver;
    public TextMeshProUGUI bestScoreTextContinue;
    public TextMeshProUGUI currentScoreTextGameOver;
    public TextMeshProUGUI currentScoreTextContinue;
    public static int finalScore;

    void Start()
    {
        gameOver = false;

    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
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

        if (Input.GetKeyDown(KeyCode.Escape) && (gameOver == false))
        {
            if (pausePanel.activeSelf)
            {
                Time.timeScale = 1;
                if (sceneName != "Tutorial")
                    gameUI.SetActive(true);
                HidePausePanel();
            }
            else
            {
                Time.timeScale = 0;
                gameUI.SetActive(false);
                ShowPausePanel();

            }
            if(settingsPanel.activeSelf)
                settingsPanel.SetActive(false);


        }

    }

    void GameOver()
    {   
        gameOverPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(restartMenuFirst);
        crosshairPanel.SetActive(false);
        PlayerShooting.canShoot = false;
        backGroundMusic.Pause();
        Cursor.visible = true;
        PlayerController.canMove = false;
        gameUI.SetActive(false);
        currentScoreTextGameOver.text = uiControl.score.ToString("0");
        if (uiControl.score > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", uiControl.score);
            bestScoreTextGameOver.text = uiControl.score.ToString("0");
        }
        else
        {
            bestScoreTextGameOver.text = PlayerPrefs.GetInt("bestScore").ToString("0");
        }
  


    }

    void ShowContinuePanel()
    {
        gameOver = true;
        EventSystem.current.SetSelectedGameObject(continueMenuFirst);
        continuePanel.SetActive(true);
        crosshairPanel.SetActive(false);
        PlayerShooting.canShoot = false;
        backGroundMusic.Pause();
        Cursor.visible = true;
        gameUI.SetActive(false);
        currentScoreTextContinue.text = uiControl.score.ToString("0");
        if (uiControl.score > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", uiControl.score);
            bestScoreTextContinue.text = uiControl.score.ToString("0");
        }
        else
        {
            bestScoreTextContinue.text = PlayerPrefs.GetInt("bestScore").ToString("0");
        }
    }

    void ShowPausePanel() 
    {
        Cursor.visible = true;
        EventSystem.current.SetSelectedGameObject(pauseMenuFirst);
        backGroundMusic.Pause();
        pausePanel.SetActive(true);
        crosshairPanel.SetActive(false);
        PlayerShooting.canShoot = false;
    }
    void HidePausePanel()
    {
        Cursor.visible = false;
        pausePanel.SetActive(false);
        backGroundMusic.UnPause();
        crosshairPanel.SetActive(true);
        PlayerShooting.canShoot = true;
    }



}
