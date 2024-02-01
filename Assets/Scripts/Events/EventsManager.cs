using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraPos;
    public GameObject continuePanel;
    public GameObject crosshairPanel;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public AudioSource backGroundMusic;
    public GameObject gameUI;
    static public Collider[] Colliders;
    public int tileIndex;
    public float respawnZ;
    private CountDownController countDownScript;
    public static float speedAtDeath = 10f;
    public static float hSpeedAtDeath = 5f;
    public static float vSpeedAtDeath = 5f;

    private void Start()
    {
        countDownScript = GetComponent<CountDownController>();
    }
    public void ContinueGame()
    {
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
        Application.Quit();
    }

    public void ContinueRun()
    {
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
        SceneManager.LoadScene("MainMenu");
        
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
        settingsPanel.SetActive(true);
        pausePanel.SetActive(false);


    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);

    }

}

