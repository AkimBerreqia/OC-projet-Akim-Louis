using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMovement : MonoBehaviour
{
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public int direction = 1;
    public float speed = .001f;

    // Start is called before the first frame update
    void Start()
    {
        minPosition = transform.position;
        maxPosition = minPosition + new Vector3(0, .5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= minPosition.y)
        {
            direction = 1;
        }

        else if (transform.position.y >= maxPosition.y)
        {
            direction = -1;
        }

        transform.Translate(Vector3.up * direction * speed);
    }
}
