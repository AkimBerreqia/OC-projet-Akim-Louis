using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;
    public float invincibleFramesCoolDown = 0.2f;
    public float initialDamage = 0f;
    public float height = 70;
    public float width = 360;
    public float newWidth;
    public bool canMove = true;

    public SpriteRenderer enemyColor;
    public Rigidbody2D enemyMass;
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
        enemyColor.material.SetColor("_Color", Color.gray);
        enemyMass.mass = 20;
        canMove = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyMass.mass = 1000;
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
