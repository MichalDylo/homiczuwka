using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("galaga");
    }

    public void OpenTutorial()
    {
        Debug.Log("Opened the tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
