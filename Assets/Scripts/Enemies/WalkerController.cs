using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : MainEnemyController
{
    public float speed;
    public float distance;
    private float positionLeft;
    private float positionRight;
    public bool isMovingRight;
    public SpriteRenderer spriteR;

    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        isMovingRight = false;
        positionLeft = gameObject.transform.position.x - distance;
        positionRight = gameObject.transform.position.x + distance;
    }

    void Update()
    {
        if (isMovingRight)
        {
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (transform.position.x >= positionRight)
        {
            isMovingRight = false;
            spriteR.flipX = false;
        }

        if (transform.position.x <= positionLeft)
        {
            isMovingRight = true;
            spriteR.flipX = true;
        }
    }
}
