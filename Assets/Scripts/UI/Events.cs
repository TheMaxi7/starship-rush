using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{

    public void ContinueGame()
    {
        SceneManager.LoadScene("Level1");
        CollectibleControl.heartCount--;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
        CollectibleControl.heartCount = 0;
        CollectibleControl.ammoCount = 0;
        CollectibleControl.starCount = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
