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
    public void ContinueGame()
    {   
        ResetComponents();
        uiControl.heartCount--;
        PlayerShooting.canShoot = true;
        crosshairPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("RestartScene");
        uiControl.heartCount = 0;
        uiControl.ammoCount = 0;
        uiControl.starCount = 0;
        GenerateLevel.zPos = 200;
        PlayerController.forwardSpeed = 10f;
        PlayerShooting.canShoot = true;
        crosshairPanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetComponents()
    {
        Collider playerCollider = player.GetComponentInChildren<Collider>();
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        player.transform.position = new Vector3(0f, 1.66f, uiControl.points*10);
        player.transform.rotation = Quaternion.identity;
        cameraPos.transform.position = new Vector3(0f, 2.81f, uiControl.points * 10 - 6.72f);
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
        playerRigidbody.MovePosition(new Vector3(0f, 1.66f, GenerateLevel.zPos - 25f));
        playerRigidbody.MoveRotation(Quaternion.identity);

        player.SetActive(true);
        PlayerManager.gameOver = false;
        continuePanel.SetActive(false);
        playerCollider.enabled = false;
        StartCoroutine(EnableCollision(playerCollider, 3));
    }

    private IEnumerator EnableCollision(Collider collider, float delay)
    {
        yield return new WaitForSeconds(delay);
        collider.enabled = true;
    }
}

