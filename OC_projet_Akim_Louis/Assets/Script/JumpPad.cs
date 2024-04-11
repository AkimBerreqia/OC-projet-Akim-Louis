using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Rigidbody2D rb;

    public float bounce = 500f;
    public bool isBouncing = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpPad"))
        {
            rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            isBouncing = true;
        }
    }
}
