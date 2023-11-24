using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject player;
    public GameObject continuePanel;
    public void ContinueGame()
    {   
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        player.transform.position = new Vector3(0f, 1.66f, GenerateLevel.zPos - 25f);
        player.transform.rotation = Quaternion.identity;
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
        playerRigidbody.MovePosition(new Vector3(0f, 1.66f, GenerateLevel.zPos - 25f));
        playerRigidbody.MoveRotation(Quaternion.identity);

        player.SetActive(true);
        PlayerManager.gameOver = false;
        continuePanel.SetActive(false);
        uiControl.heartCount--;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("RestartScene");
        uiControl.heartCount = 0;
        uiControl.ammoCount = 0;
        uiControl.starCount = 0;
        GenerateLevel.zPos = 25f;
        PlayerController.forwardSpeed = 10f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}