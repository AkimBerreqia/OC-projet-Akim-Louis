using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MedicalKitNumber : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameOverAndPauseMenu gameOverAndPauseMenu;

    public GameObject currentMedicalKitsNum;
    public GameObject presseE2RefillKits;
    public int number = 0;
    public int maxNumber = 5;
    public float recovery = 20;
    public bool canRefillKits = false;
    public bool showText = false;

    private TextMeshProUGUI currentMedicalKitsNumText;

    // Start is called before the first frame update
    void Start()
    {
        currentMedicalKitsNumText = currentMedicalKitsNum.GetComponent<TextMeshProUGUI>();
        presseE2RefillKits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentMedicalKitsNumText.text = number.ToString();

        if (showText && !gameOverAndPauseMenu.isPaused)
        {
            presseE2RefillKits.SetActive(true);
            canRefillKits = true;
        }

        else
        {
            presseE2RefillKits.SetActive(false);
            canRefillKits = false;
        }

        if (Input.GetKeyDown(KeyCode.H) && number > 0 && playerHealth.currentHealth < playerHealth.maxHealth && 
            Time.time - playerHealth.invincibleFramesCoolDown >= playerHealth.initialHealthSetting && 
            !gameOverAndPauseMenu.isPaused)
        {
            playerHealth.PlayerRecovers(recovery);
            number--;
        }

        if (Input.GetKeyDown(KeyCode.E) && canRefillKits == true)
        {
            number = maxNumber;
            canRefillKits = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heal" && number < maxNumber)
        {
            Destroy(collision.gameObject);
            number++;
        }

        else if (collision.gameObject.tag == "HealShelf")
        {
            showText = true;
            canRefillKits = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HealShelf" && !gameOverAndPauseMenu.isPaused)
        {
            showText = false;
            canRefillKits = false;
        }
    }
}
