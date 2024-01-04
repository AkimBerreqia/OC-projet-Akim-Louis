using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Power power;
    public Mana mana;
    public GameObject CurrentProjectile;

    public bool leftShotingDirection = false;
    public bool rightShotingDirection = false;
    public int shotingDirection;
    public float timeShot;
    public float projectileCoolDown = 2f;
    public bool coolDown = false;
    public bool onShot = false;
    private string shotLeft = "j";
    private string shotRight = "k";
    public Color chosenColor;

    void InstantiateProjectile()
    {
        if (Time.time - timeShot >= projectileCoolDown * 0.5 && mana.currentMana >= power.currentManaCost)
        {
            coolDown = false;
            leftShotingDirection = false;
            rightShotingDirection = false;

            if (Time.time - timeShot >= projectileCoolDown * 1.5)
            {
                mana.canRecover = true;
            }
        }

        if ((Input.GetKeyDown(shotLeft) == true || Input.GetKeyDown(shotRight) == true) && coolDown == false && mana.currentMana > 0)
        {
            if (Input.GetKeyDown(shotLeft) == true)
            {
                leftShotingDirection = true;
                shotingDirection = -1;
            }
            else if (Input.GetKeyDown(shotRight) == true)
            {
                rightShotingDirection = true;
                shotingDirection = 1;
            }
            chosenColor = power.CurrentColor;
            onShot = true;
            coolDown = true;
            mana.canRecover = false;
        }

        if (onShot == true && mana.currentMana > 0)
        {
            GameObject projectile = Instantiate(CurrentProjectile, transform.position + new Vector3(), transform.rotation);
            onShot = false;
            mana.SetMana(power.currentManaCost);
            timeShot = Time.time;
            Destroy(projectile, projectileCoolDown);

            if (power.CurrentColor == Color.green)
            {
                playerHealth.canRecover = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateProjectile();
    }
}