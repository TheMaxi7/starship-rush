using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    private void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        EventSystem.current.SetSelectedGameObject(PlayButton);
    }
    public void Play()
    {
        if (PlayerPrefs.GetInt("TutorialHasPlayed") <= 0)
        {
            SceneManager.LoadScene("Tutorial");
        } else
        {
            SceneManager.LoadScene("Level1");
            uiControl.heartCount = 0;
            uiControl.ammoCount = 15;
            uiControl.starCount = 0;
            GenerateLevel.zPos = 200;
            PlayerController.forwardSpeed = 10f;
            Time.timeScale = 1;
            PlayerShooting.canShoot = false;
            PlayerController.canMove = false;
        }
            
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
     
       
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
