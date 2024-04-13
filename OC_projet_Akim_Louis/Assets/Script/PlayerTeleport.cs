using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    public GameObject presseE2Teleport;

    public GameOverAndPauseMenu gameOverAndPauseMenu;

    public bool canTeleport = false;
    public bool showText = false;

    void Start()
    {
        presseE2Teleport.SetActive(false);
    }

    void Update()
    {
        if (showText && !gameOverAndPauseMenu.isPaused)
        {
            presseE2Teleport.SetActive(true);
            canTeleport = true;
        }
        
        else
        {
            presseE2Teleport.SetActive(false);
            canTeleport = false;

        }

        if (Input.GetKeyDown(KeyCode.E) && currentTeleporter != null && canTeleport && !gameOverAndPauseMenu.isPaused)
        {
            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            canTeleport = true;
            showText = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
                canTeleport = false;
                showText = false;
            }
        }
    }
}