using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public EnterBlockingPlatform enterBlockingPlatform;
    public GameOverAndPauseMenu gameOverAndPauseMenu;
    public GameObject EnemiesLeftToKill;

    public int lockers;

    public bool hasEnemiesToKill = false;

    void Start()
    {
        EnemiesLeftToKill.SetActive(false);
    }

    void Update()
    {
        if (lockers == 0)
        {
            hasEnemiesToKill = false;
        }

        if (gameOverAndPauseMenu.isPaused)
        {
            EnemiesLeftToKill.SetActive(false);
        }

        else if (!gameOverAndPauseMenu.isPaused && hasEnemiesToKill)
        {
            EnemiesLeftToKill.SetActive(true);
        }

        else
        {
            EnemiesLeftToKill.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !enterBlockingPlatform.enemiesDefeated)
        {
            enterBlockingPlatform.BlockingPlatform.SetActive(true);
            hasEnemiesToKill = true;
        }
    }
}
