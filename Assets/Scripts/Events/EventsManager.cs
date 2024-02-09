using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject player;
    public GameObject cameraPos;
    public GameObject continuePanel;
    public GameObject crosshairPanel;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject gameUI;
    public AudioSource backGroundMusic;
    public Animator gameOverAnim;
    public Animator continueAnim;
    public Animator pauseAnim;

    [Header("Variables")]
    public int tileIndex;
    public float respawnZ;
    static public Collider[] Colliders;
    private CountDownController countDownScript;
    public static float speedAtDeath = 10f;
    public static float hSpeedAtDeath = 5f;
    public static float vSpeedAtDeath = 5f;
    public static int currentPlayerStars;

    private void Start()
    {
        
        countDownScript = GetComponent<CountDownController>();
        currentPlayerStars = PlayerPrefs.GetInt("Stars");
    }
    public void ContinueGame()
    {
        continueAnim.SetTrigger("Close");
        speedAtDeath = PlayerController.forwardSpeed;
        vSpeedAtDeath = PlayerController.verticalSpeed;
        hSpeedAtDeath = PlayerController.horizontalSpeed;
        UIManager.gameOver = false;
        ResetComponents();
        uiController.heartCount--;
        ShootingController.canShoot = true;
        crosshairPanel.SetActive(true);
        backGroundMusic.UnPause();
        gameUI.SetActive(true);
        PlayerController.forwardSpeed = 0;
        
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt("Stars", currentPlayerStars + uiController.starCount);
        gameOverAnim.SetTrigger("Close");
        SceneManager.LoadScene("RestartScene");
        uiController.heartCount = 0;
        uiController.ammoCount = 15;
        uiController.starCount = 0;
        GenerateSections.zPos = 200;
        speedAtDeath = 10f;
        vSpeedAtDeath = 5f;
        hSpeedAtDeath = 5f;
        Time.timeScale = 1;
        ShootingController.canShoot = false;
        PlayerController.canMove = false;
        crosshairPanel.SetActive(true);
    }
    public void QuitGame()
    {
        PlayerPrefs.SetInt("Stars", currentPlayerStars + uiController.starCount);
        Application.Quit();
    }

    public void ContinueRun()
    {
        pauseAnim.SetTrigger("Close");
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Time.timeScale = 1;
        crosshairPanel.SetActive(true);
        pausePanel.SetActive(false);
        backGroundMusic.UnPause();
        ShootingController.canShoot = true;
        if (sceneName != "Tutorial")
            gameUI.SetActive(true);
    }


    public void ResetComponents()
    {
        StartCoroutine(countDownScript.CountDownToStart());
        tileIndex = (int)(player.transform.position.z / 25f);
        respawnZ = 25f * tileIndex;
        Collider[] playerCollider = player.GetComponentsInChildren<Collider>();
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        player.transform.position = new Vector3(0f, 1.66f, respawnZ);
        player.transform.rotation = Quaternion.identity;
        cameraPos.transform.position = new Vector3(0f, 2.81f, respawnZ - 6.72f);
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
        playerRigidbody.MovePosition(new Vector3(0f, 1.66f, respawnZ));
        playerRigidbody.MoveRotation(Quaternion.identity);
        player.SetActive(true);
        UIManager.gameOver = false;
        continuePanel.SetActive(false);
        foreach (Collider collider in playerCollider)
        {
            collider.enabled = false;
           
        }
        
        StartCoroutine(EnableCollision(playerCollider, 5));
    }

    public void RestartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        uiController.heartCount = 0;
        uiController.ammoCount = 15;
        uiController.starCount = 0;
        GenerateSections.zPos = 200;
        ShootingController.canShoot = false;
        TutPlayerController.canMove = false;
        
        crosshairPanel.SetActive(false);
    }

    public void BackToMenu()
    { 
        PlayerPrefs.SetInt("Stars", currentPlayerStars + uiController.starCount);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale= 1;
        
    }

    private IEnumerator EnableCollision(Collider[] collider, float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (Collider _collider in collider)
        {
            _collider.enabled = true;

        }
    }

    public void OpenSettings()
    {
        gameUI.SetActive(false);
        settingsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void CloseSettings()
    {
        gameUI.SetActive(true);
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
        continueAnim.SetTrigger("Close");

    }

}

