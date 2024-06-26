using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Power power;
    public Enemy enemy;

    public float speed;

    private bool movingRight = true;

    public Transform groundDetection;

    void Update()
    {
        if (enemy.canMove == true)
        {
            transform.Translate(Vector2.right * speed * power.ennemySpeedMultiplicator * Time.deltaTime);
        }

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);


        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
            }
            
        }
    }
}
