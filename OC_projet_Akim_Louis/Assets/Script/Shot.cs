using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Mana mana;
    public Enemy enemy;
    public Projectile projectile;
    public Power power;
    
    public GameObject CurrentProjectile;
    public Renderer ProjectileColor;
    public PlayerMovement playerMovement;
    
    public LayerMask enemyLayers;
    public int currentShotingDireciton;
    public float attackRange = 0.5f;

    void Attack()
    {
        Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(CurrentProjectile.transform.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(power.currentDamage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ProjectileColor.material.SetColor("_Color", projectile.chosenColor);

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
        CurrentProjectile.transform.Translate(Vector2.right * currentShotingDireciton * power.speedMultiplicator * playerMovement.speed * Time.deltaTime);

        Attack();
    }

    // It makes the attack range visible
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(CurrentProjectile.transform.position, attackRange);
    }
}
