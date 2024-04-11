using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEmergence : MonoBehaviour
{
    public GameObject BossInfos;
    public GameObject Boss;

    public GameOverAndPauseMenu gameOverAndPauseMenu;

    public int enemyNumber = 4;
    // Start is called before the first frame update
    void Start()
    {
        BossInfos.SetActive(false);
        Boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyNumber == 0)
        {
            if (gameOverAndPauseMenu.isPaused)
            {
                BossInfos.SetActive(false);
                Boss.SetActive(false);
            }

            else
            {
                BossInfos.SetActive(true);
                Boss.SetActive(true);
            }
        }
    }
}
