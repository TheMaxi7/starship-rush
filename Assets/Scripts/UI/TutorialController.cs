using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public GameObject[] PopUps;
    public float movementTime = 8f; 
    public static int popUpIndex = 0;
    public GameObject GameUi;
    public GameObject Crosshair;
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

        if (uiController.points == 15)
        {
            EndTutPanel.SetActive(true);
            TutPlayerController.canMove = false;
            ShootingController.canShoot = false;
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
            	ShootingController.canShoot = true;
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
        ShootingController.canShoot = false;
        Crosshair.SetActive(false);
        uiController.heartCount = 0;
        uiController.ammoCount = 5;
        uiController.starCount = 0;
        GenerateSections.zPos = 200;
    }

    private IEnumerator StartLevelOne()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Level1");
        TutPlayerController.canMove = true;
        ShootingController.canShoot = false;
        uiController.heartCount = 0;
        uiController.ammoCount = 15;
        uiController.starCount = 0;
        GenerateSections.zPos = 200;
    }
}
