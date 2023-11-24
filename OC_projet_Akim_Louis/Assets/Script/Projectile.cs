using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Power power;
    public Mana mana;
    public GameObject CurrentProjectile;

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
        if (Time.time - timeShot >= projectileCoolDown)
        {
            coolDown = false;
            mana.canRecover = true;
        }

        if ((Input.GetKeyDown(shotLeft) == true || Input.GetKeyDown(shotRight) == true) && coolDown == false)
        {
            if (Input.GetKeyDown(shotLeft) == true)
            {
                shotingDirection = -1;
                chosenColor = power.colorParts[0];
            }
            else if (Input.GetKeyDown(shotRight) == true)
            {
                shotingDirection = 1;
                chosenColor = power.colorParts[1];
            }
            onShot = true;
            coolDown = true;
        }

        if (onShot == true && mana.currentMana > 0)
        {
            GameObject projectile = Instantiate(CurrentProjectile, transform.position + new Vector3(2 * shotingDirection, 0, 10), transform.rotation);
            onShot = false;
            mana.SetMana(-20);
            timeShot = Time.time;
            Destroy(projectile, projectileCoolDown);
        }
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateProjectile();
    }
}