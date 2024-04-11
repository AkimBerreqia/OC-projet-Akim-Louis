using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public EnterBlockingPlatform enterBlockingPlatform;

    public int lockers;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !enterBlockingPlatform.enemiesDefeated)
        {
            enterBlockingPlatform.BlockingPlatform.SetActive(true);
        }
    }
}
