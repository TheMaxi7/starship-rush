using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenOptions()
    {
        //do something
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
