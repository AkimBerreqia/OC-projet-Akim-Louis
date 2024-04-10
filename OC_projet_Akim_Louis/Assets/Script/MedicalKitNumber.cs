using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MedicalKitNumber : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public GameObject currentMedicalKitsNum;
    public int number = 0;
    public int maxNumber = 5;
    public float recovery = 10;

    public TextMeshProUGUI currentMedicalKitsNumText;

    // Start is called before the first frame update
    void Start()
    {
        currentMedicalKitsNumText = currentMedicalKitsNum.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMedicalKitsNumText.text = number.ToString();

        if (Input.GetKeyDown(KeyCode.H) && number > 0 && playerHealth.currentHealth < playerHealth.maxHealth && 
            Time.time - playerHealth.invincibleFramesCoolDown >= playerHealth.initialHealthSetting)
        {
            playerHealth.PlayerRecovers(recovery);
            number--;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heal" && number < maxNumber)
        {
            Destroy(collision.gameObject);
            number++;
        }
    }
}
