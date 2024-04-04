using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SetHealth setHealth;
    public Power power;

    public float currentHealth;
    public float maxHealth = 100;
    public float invincibleFramesCoolDown = 1f;
    public float initialDamage;
    public float height = 70;
    public float width = 360;
    public float newWidth;
    public float lengthTime = 1f;
    public float initialTime;
    public float fireDamage;

    public bool canMove = true;
    public bool isAlive = true;
    public bool isFired = false;

    public object[] healthInfos;

    public SpriteRenderer enemyColor;
    public Rigidbody2D enemyMass;
    public RectTransform healthTransform;

    public void EnemyGetsDamaged(float damage)
    {
        healthInfos = setHealth.TakeDamage(damage, invincibleFramesCoolDown, currentHealth, maxHealth, newWidth, width, height, healthTransform, initialDamage);

        currentHealth = (float)healthInfos[0];
        initialDamage = (float)healthInfos[1];

        newWidth = (float)healthInfos[2];
        healthTransform.sizeDelta = new Vector2(newWidth, height);
    }

    void Die()
    {
        enemyColor.material.SetColor("_Color", Color.gray);
        enemyMass.mass = 20;
        canMove = false;
        isAlive = false;
    }

    void GetsFired()
    {
        if (isFired == true && Time.time - initialTime < lengthTime)
        {
            EnemyGetsDamaged(power.fireDamage);
        }
        
        else
        {
            isFired = false;
        }
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

        GetsFired();
    }
}
