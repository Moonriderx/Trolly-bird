using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed;
    float groundLength;
    public float destroyColumnLimit;
    BoxCollider2D groundCol;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            groundCol = GetComponent<BoxCollider2D>();
            groundLength = groundCol.size.x;
        }
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); // move ground left every frame
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundLength)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundLength, transform.position.y);
            }
        }

        if (gameObject.CompareTag("Column"))
        {
            if (transform.position.x <= destroyColumnLimit)
            {
                Destroy(gameObject);
            }
        }
    }
}
