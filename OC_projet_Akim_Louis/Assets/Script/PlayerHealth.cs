using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Power power;
    public SetHealth setHealth;

    public GameObject PlayerInfos;
    public GameObject MedicalKitsInfos;
    public GameObject ArmIcon;
    public GameObject GameOverPauseMenu;
    public GameObject PauseTitle;
    public GameObject GameOverTitle;
    public GameObject ContinueButton;
    public GameObject WinTitle;

    public float currentHealth;
    public float maxHealth = 100;
    public float invincibleFramesCoolDown = 1f;
    public float initialHealthSetting;
    public float initialDamage;
    public float height = 70;
    public float width = 360;
    public float newWidth;
    public bool canMove = true;
    public bool isAlive = true;

    public object[] healthInfos;

    public SpriteRenderer playerColor;
    public Rigidbody2D playerMass;
    public RectTransform healthTransform;

    public void PlayerRecovers(float recovery)
    {
        healthInfos = setHealth.GainHealth(recovery, invincibleFramesCoolDown, currentHealth, maxHealth, newWidth, width, height, healthTransform, initialHealthSetting);

        currentHealth = (float)healthInfos[0];
        initialHealthSetting = (float)healthInfos[1];

        newWidth = (float)healthInfos[2];
        healthTransform.sizeDelta = new Vector2(newWidth, height);
    }

    public void PlayerLoosesHealth()
    {
        healthInfos = setHealth.TakeDamage(20f, invincibleFramesCoolDown, currentHealth, maxHealth, newWidth, width, height, healthTransform, initialDamage);

        currentHealth = (float)healthInfos[0];
        initialDamage = (float)healthInfos[1];

        newWidth = (float)healthInfos[2];
        healthTransform.sizeDelta = new Vector2(newWidth, height);
    }

    public void Die()
    {
        playerColor.material.SetColor("_Color", Color.gray);
        canMove = false;
    }

    void GameOver()
    {
        Die();
        isAlive = false;
        PlayerInfos.SetActive(false);
        MedicalKitsInfos.SetActive(false);
        ArmIcon.SetActive(false);
        GameOverPauseMenu.SetActive(true);
        GameOverTitle.SetActive(true);
        PauseTitle.SetActive(false);
        ContinueButton.SetActive(false);
        WinTitle.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerMass.mass = 20;
        GameOverPauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            GameOver();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.GetComponent<Enemy>().isAlive == true)
        {
            PlayerLoosesHealth();
        }
    }
}
