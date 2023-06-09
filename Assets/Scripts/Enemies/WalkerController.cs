using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : MainEnemyController
{
    [Header("Variables del enemigo - Walker")]
    public float speed;
    public float distance;

    [Header("Otros")]
    public bool isMovingRight;

    [Header("Referencias")]
    public SpriteRenderer spriteR;
    
    private float positionLeft;
    private float positionRight;

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
