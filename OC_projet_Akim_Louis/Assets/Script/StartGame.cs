using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public BuildScene buildScene;

    public GameObject StartWindow;
    public GameObject ChooseLevelWindow;

    public void ChooseLevel()
    {
        StartWindow.SetActive(false);
        ChooseLevelWindow.SetActive(true);
    }

    public void Back()
    {
        StartWindow.SetActive(true);
        ChooseLevelWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
