using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public BuildScene buildScene;

    public void LevelTest()
    {
        buildScene.ChangeScene("LevelTest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
