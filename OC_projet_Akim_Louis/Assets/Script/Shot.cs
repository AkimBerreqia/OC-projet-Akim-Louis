using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Mana mana;
    public Enemy enemy;
    public Projectile projectile;
    public Power power;
    public SetHealth setHealth;
    
    public GameObject CurrentProjectile;
    public Renderer ProjectileColor;
    public PlayerMovement playerMovement;
    
    public LayerMask enemyLayers;
    public int currentShotingDireciton;
    public float attackRange = 0.5f;
    public float spellBuff = 1f;

    void Attack()
    {
        Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(CurrentProjectile.transform.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnnemies)
        {
            if (enemy.GetComponent<Enemy>().isAlive)
            {
                enemy.GetComponent<Enemy>().EnemyGetsDamaged(power.currentDamage * spellBuff);

                if (projectile.chosenColor == Color.red)
                {
                    enemy.GetComponent<Enemy>().isFired = true;
                    enemy.GetComponent<Enemy>().initialTime = Time.time;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ProjectileColor.enabled = true;
        ProjectileColor.material.SetColor("_Color", projectile.chosenColor);
        spellBuff = 1f;
        
        if (projectile.chosenColor == Color.green)
        {
            ProjectileColor.enabled = false;
            power.spellIsBuffed = true;
        }

        else if (projectile.chosenColor != Color.green && power.spellIsBuffed == true)
        {
            power.spellIsBuffed = false;
            spellBuff = 2f;
        }

        if (projectile.leftShotingDirection == true)
        {
            currentShotingDireciton = -1;
        }

        else if (projectile.rightShotingDirection == true)
        {
            currentShotingDireciton = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentProjectile.transform.Translate(Vector2.right * currentShotingDireciton * power.speedMultiplicator * playerMovement.speed * Time.deltaTime * spellBuff);

        Attack();
    }

    // It makes the attack range visible
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(CurrentProjectile.transform.position, attackRange);
    }
}
