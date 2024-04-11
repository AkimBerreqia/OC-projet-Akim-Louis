using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnterBlockingPlatform : MonoBehaviour
{
    public GameObject BlockingPlatform;
    public bool isLocked = false;
    public bool enemiesDefeated = false;

    private void Start()
    {
        BlockingPlatform.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BlockingPlatform.SetActive(true);
        }
    }
}
