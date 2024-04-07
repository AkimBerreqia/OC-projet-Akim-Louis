using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameOverAndPauseMenu gameOverAndPauseMenu;

    public GameObject GameOverPauseMenu;
    public GameObject WinTitle;
    public GameObject PauseTitle;
    public GameObject ContinueButton;

    void Win()
    {
        gameOverAndPauseMenu.Pause();
        PauseTitle.SetActive(false);
        WinTitle.SetActive(true);
        ContinueButton.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RoastyMeat")
        {
            Win();
        }
    }
}
