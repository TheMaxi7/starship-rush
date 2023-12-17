using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPopUps : MonoBehaviour
{
    public GameObject[] PopUps;
    public float movementTime = 8f; 
    public static int popUpIndex = 0;
    public GameObject GameUi;
    public GameObject Crosshair;
    public GameObject GameOverPanel;
    public GameObject EndTutPanel;
    public static bool inTutorial = true;
    
    private void Start()
    {
    
        ShowNextPopUp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PopUps[popUpIndex-1].SetActive(false);
            StartCoroutine(MovePlayerForTime());

        }
        if (UIManager.gameOver == true) 
        {
            StartCoroutine(ReloadTutorial());
        }

        if (uiControl.points == 15)
        {
            EndTutPanel.SetActive(true);
            TutPlayerController.canMove = false;
            PlayerShooting.canShoot = false;
            PlayerPrefs.SetInt("TutorialHasPlayed", 1);
            inTutorial = false;
            StartCoroutine(StartLevelOne());
        }
    }

    private IEnumerator MovePlayerForTime()
    {
        if (popUpIndex < PopUps.Length)
        {
            TutPlayerController.canMove = true;
            yield return new WaitForSeconds(movementTime);
            TutPlayerController.canMove = false;
	    if (UIManager.gameOver == false)	
            	ShowNextPopUp();     	
        }
        else
        {
            TutPlayerController.canMove = true;
        }
    }

    private void ShowNextPopUp()
    {
        if (popUpIndex < PopUps.Length)
        {
            PopUps[popUpIndex].SetActive(true);
            if (popUpIndex == 1)
            {
            	Crosshair.SetActive(true);
            	PlayerShooting.canShoot = true;
            }
            	
            if (popUpIndex >= 2)
            	GameUi.SetActive(true);
            popUpIndex++;
        }
        else
        {
            TutPlayerController.canMove = true;
        }
    }
    private  IEnumerator ReloadTutorial()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Tutorial");
        popUpIndex= 0;
        TutPlayerController.canMove = false;
        PlayerShooting.canShoot = false;
        Crosshair.SetActive(false);
        uiControl.heartCount = 0;
        uiControl.ammoCount = 5;
        uiControl.starCount = 0;
        GenerateLevel.zPos = 200;
    }

    private IEnumerator StartLevelOne()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Level1");
        TutPlayerController.canMove = true;
        PlayerShooting.canShoot = false;
        uiControl.heartCount = 0;
        uiControl.ammoCount = 5;
        uiControl.starCount = 0;
        GenerateLevel.zPos = 200;
    }
}
