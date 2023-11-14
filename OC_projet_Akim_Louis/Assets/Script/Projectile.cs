using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Power power;
    public GameObject CurrentProjectile;

    public int shotingDirection;
    private float timeShot;
    public float projectileCoolDown = 2f;
    public bool coolDown = false;
    public bool onShot = false;
    private string shotLeft = "j";
    private string shotRight = "k";
    public Color chosenColor;

    void instantiateProjectile()
    {
        if (Time.time - timeShot >= projectileCoolDown)
        {
            coolDown = false;
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

        if (onShot == true)
        {
            GameObject projectile = Instantiate(CurrentProjectile, transform.position + new Vector3(2 * shotingDirection, 0, 10), transform.rotation);
            onShot = false;
            timeShot = Time.time;
            Destroy(projectile, projectileCoolDown);
        }
    }

    // Update is called once per frame
    void Update()
    {
        instantiateProjectile();
    }
}