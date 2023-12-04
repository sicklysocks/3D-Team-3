using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void OnClickHelp()
    {
        SceneManager.LoadScene("Help");
    }
    public void OnClickCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnClickReturn()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
