using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public float speed;
    public float distance;
    private float positionLeft;
    private float positionRight;
    public bool isMovingRight;

    public SpriteRenderer spriteR;
    public ParticleSystem executionParticle;

    public bool isAttacking;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask player;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        isMovingRight = false;
        isAttacking = false;
        positionLeft = gameObject.transform.position.x - distance;
        positionRight = gameObject.transform.position.x + distance;
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        if (!isAttacking)
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

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player);

        foreach (Collider2D enemy in hitEnemies)
        {

        }
    }

    public void Die()
    {
        Destroy(this, 0);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
