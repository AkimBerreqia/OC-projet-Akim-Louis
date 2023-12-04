using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;
    public float invincibleFramesCoolDown = 0.4f;
    public float initialDamage = 0f;
    public float height = 70;
    public float width = 360;
    public float newWidth;

    public SpriteRenderer playerColor;
    public Rigidbody2D playerMass;
    public RectTransform HealthTransform;

    public void TakeDamage(float damage)
    {
        if (Time.time - invincibleFramesCoolDown >= initialDamage)
        {
            if (currentHealth < System.Math.Abs(damage))
            {
                currentHealth = 0;
            }

            else
            {
                currentHealth -= damage;
            }
        }

        initialDamage = Time.time;

        newWidth = currentHealth / maxHealth * width;
        HealthTransform.sizeDelta = new Vector2(newWidth, height);
    }

    void Die()
    {
        playerColor.material.SetColor("_Color", Color.gray);
        playerMass.mass = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerMass.mass = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            Die();
        }
    }
}
