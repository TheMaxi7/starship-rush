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
    public GameObject shopPanel;
    public GameObject inventoryPanel;

    public Animator anim;
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
            uiController.heartCount = 0;
            uiController.ammoCount = 15;
            uiController.starCount = 0;
            GenerateSections.zPos = 200;
            PlayerController.forwardSpeed = 10f;
            Time.timeScale = 1;
            ShootingController.canShoot = false;
            PlayerController.canMove = false;
        }
            
    }
    
    public void OpenShop()
    {
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
    }

    public void CloseInvetory()
    {
        inventoryPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
     
       
    }

    public void CloseSettings()
    {
        anim.SetTrigger("Close");
        Invoke("OpenMainMenu", 0.2f);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnBecameInvisible()
    {
        Invoke("OpenSettings", 0.6f);
    }
    public void NewGame()
    {
        Invoke("Play", 0.6f);
    }

    public void InvQuit()
    {
        Invoke("ExitGame", 0.6f);
    }
    
    public void OpenMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
