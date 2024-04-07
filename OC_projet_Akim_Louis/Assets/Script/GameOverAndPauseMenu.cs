using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverAndPauseMenu : MonoBehaviour
{
    public BuildScene buildScene;
    public PlayerHealth playerHealth;

    public GameObject PlayerInfos;
    public GameObject ArmIcon;
    public GameObject GameOverPauseMenu;
    public GameObject GameOverTitle;
    public GameObject WinTitle;

    public bool isPaused = false;

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void BackToMenu()
    {
        buildScene.ChangeScene("HomeScene");
    }

    public void Pause()
    {
        if (isPaused == true)
        {
            Time.timeScale = 1.0f;
            PlayerInfos.SetActive(true);
            ArmIcon.SetActive(true);
            GameOverPauseMenu.SetActive(false);

            isPaused = false;
        }

        else
        {
            Time.timeScale = 0f;
            PlayerInfos.SetActive(false);
            ArmIcon.SetActive(false);
            GameOverPauseMenu.SetActive(true);
            GameOverTitle.SetActive(false);
            WinTitle.SetActive(false);

            isPaused = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
