using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public GameObject CurrentProjectile;
    public Renderer ProjectileColor;
    public Projectile projectile;
    public PlayerMovement playerMovement;
    public int currentShotingDireciton;

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
        CurrentProjectile.transform.Translate(Vector2.right * currentShotingDireciton * playerMovement.speed * Time.deltaTime);
    }
}
