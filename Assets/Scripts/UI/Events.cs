using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraPos;
    public GameObject continuePanel;
    public GameObject crosshairPanel;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public AudioSource backGroundMusic;
    public GameObject gameOverPanel;
    public GameObject gameUI;
    static public Collider[] Colliders;
    public int tileIndex;
    public float respawnZ;
    private CountDown countDownScript;
    public static float speedAtDeath = 10f;

    private void Start()
    {
        countDownScript = GetComponent<CountDown>();
    }
    public void ContinueGame()
    {
        speedAtDeath = PlayerController.forwardSpeed;
        UIManager.gameOver = false;
        ResetComponents();
        uiControl.heartCount--;
        PlayerShooting.canShoot = true;
        crosshairPanel.SetActive(true);
        backGroundMusic.UnPause();
        gameUI.SetActive(true);
        PlayerController.forwardSpeed = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("RestartScene");
        uiControl.heartCount = 0;
        uiControl.ammoCount = 15;
        uiControl.starCount = 0;
        GenerateLevel.zPos = 200;
        PlayerController.forwardSpeed = 10f;
        PlayerController.verticalSpeed = 5f;
        PlayerController.horizontalSpeed = 5f;
        Time.timeScale = 1;
        PlayerShooting.canShoot = false;
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
        PlayerShooting.canShoot = true;
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
        
        StartCoroutine(EnableCollision(playerCollider, 3));
    }

    public void RestartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        uiControl.heartCount = 0;
        uiControl.ammoCount = 15;
        uiControl.starCount = 0;
        GenerateLevel.zPos = 200;
        PlayerShooting.canShoot = false;
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

