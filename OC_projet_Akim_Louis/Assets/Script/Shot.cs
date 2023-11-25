using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public GameObject CurrentProjectile;
    public Renderer ProjectileColor;
    public Projectile projectile;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        ProjectileColor.material.SetColor("_Color", projectile.chosenColor);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentProjectile.transform.Translate(Vector2.right * projectile.newShotingDirection * playerMovement.speed * Time.deltaTime);
    }
}
