using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public SetHealth setHealth;
    public Power power;
    public Blocker blocker;
    public EnterBlockingPlatform enterBlockingPlatform;
    public BossEmergence bossEmergence;

    public GameObject BossInfos;
    public GameObject BossEmergence;
    public GameObject JumpPads;

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
    public bool isBoss = false;

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
        if (isAlive)
        {
            if (SceneManager.GetActiveScene().name == "lvl2")
            {
                if (blocker.lockers > 0)
                {
                    blocker.lockers--;

                    if (blocker.lockers == 0 && enterBlockingPlatform.enemiesDefeated == false)
                    {
                        enterBlockingPlatform.enemiesDefeated = true;
                        enterBlockingPlatform.BlockingPlatform.SetActive(false);
                    }
                }

                if (!isBoss)
                {
                    bossEmergence.enemyNumber--;
                }

                else if (isBoss)
                {
                    Destroy(BossInfos);
                    Destroy(bossEmergence);
                    JumpPads.SetActive(true);
                }
            }

            enemyColor.material.SetColor("_Color", Color.gray);
            canMove = false;
            isAlive = false;
            Destroy(gameObject);
        }
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

        if (SceneManager.GetActiveScene().name == "lvl2")
        {
            JumpPads.SetActive(false);
        }
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
