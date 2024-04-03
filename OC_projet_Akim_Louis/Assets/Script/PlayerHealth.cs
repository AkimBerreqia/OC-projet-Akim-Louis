using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Power power;

    public GameObject PlayerInfos;
    public GameObject ArmIcon;
    public GameObject GameOverPauseMenu;
    public GameObject PauseTitle;
    public GameObject GameOverTitle;
    public GameObject ContinueButton;


    public float currentHealth;
    public float maxHealth = 100;
    public float invincibleFramesCoolDown = 0.4f;
    public float initialHealthSetting = 0f;
    public float height = 70;
    public float width = 360;
    public float newWidth;
    public bool canRecover = false;
    public bool canMove = true;
    public bool isAlive = true;

    public SpriteRenderer playerColor;
    public Rigidbody2D playerMass;
    public RectTransform healthTransform;

    public void SetHealth(float increaseBy)
    {
        if (Time.time - invincibleFramesCoolDown >= initialHealthSetting)
        {
            if (increaseBy > maxHealth - currentHealth)
            {
                currentHealth = maxHealth;
            }

            else if (currentHealth < System.Math.Abs(increaseBy) && increaseBy < 0)
            {
                currentHealth = 0;
            }

            else
            {
                currentHealth += increaseBy;
            }
        }

        initialHealthSetting = Time.time;

        newWidth = currentHealth / maxHealth * width;
        healthTransform.sizeDelta = new Vector2(newWidth, height);
    }

    public void Die()
    {
        playerColor.material.SetColor("_Color", Color.gray);
        playerMass.mass = 1;
        canMove = false;
    }

    public void Pause()
    {
        // Pause the game
    }

    void GameOver()
    {
        Die();
        isAlive = false;
        PlayerInfos.SetActive(false);
        ArmIcon.SetActive(false);
        GameOverPauseMenu.SetActive(true);
        GameOverTitle.SetActive(true);
        PauseTitle.SetActive(false);
        ContinueButton.SetActive(false);
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

        if (canRecover == true)
            SetHealth(power.currentPlayerRecovery);
            canRecover = false;

        if (Input.GetKeyDown("g"))
        {
            SetHealth(-20);
        }
    }
}
