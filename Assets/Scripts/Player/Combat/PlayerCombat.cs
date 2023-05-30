using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public ParticleSystem attackParticle;
    public PlayerController controller;
    public PlayerMovement movement;
    public Animator anim;
    public GameManager manager;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    private int damage;

    public LayerMask enemyLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !controller.isAttacking)
        {
            Attack01();
        }

        if (Input.GetKeyDown(KeyCode.X) && !controller.isAttacking)
        {
            Attack02();
        }
        
        if ( Input.GetKeyDown(KeyCode.C) && !controller.isAttacking)
        {
            Attack03();
        }
    }

    void Attack01()
    {
        damage = 20;
        anim.SetTrigger("Attack01");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<MainEnemyController>().health - damage <= 0)
            {
                enemy.gameObject.GetComponent<MainEnemyController>().executionParticle.Play();
                manager.totalPoints = manager.totalPoints + enemy.gameObject.GetComponent<MainEnemyController>().reward;
                Destroy(enemy.gameObject, 0.5f);
                Debug.Log("Enemigo derrotado");
            }
            else
            {
                attackParticle.Play();
                enemy.GetComponent<MainEnemyController>().health -= damage;
                Debug.Log(enemy.GetComponent<MainEnemyController>().health + " HP");
            }

            
        }
    }

    void Attack02()
    {
        damage = 25;
        anim.SetTrigger("Attack02");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<MainEnemyController>().health - damage <= 0)
            {
                enemy.gameObject.GetComponent<MainEnemyController>().executionParticle.Play();
                manager.totalPoints = manager.totalPoints + enemy.gameObject.GetComponent<MainEnemyController>().reward;
                Destroy(enemy.gameObject, 0.5f);
                Debug.Log("Enemigo derrotado");
            }
            else
            {
                attackParticle.Play();
                enemy.GetComponent<MainEnemyController>().health -= damage;
                Debug.Log(enemy.GetComponent<MainEnemyController>().health);
            }
        }
    }

    void Attack03()
    {
        damage = 40;
        anim.SetTrigger("Attack03");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<MainEnemyController>().health - damage <= 0)
            {
                enemy.gameObject.GetComponent<MainEnemyController>().executionParticle.Play();
                manager.totalPoints = manager.totalPoints + enemy.gameObject.GetComponent<MainEnemyController>().reward;
                Destroy(enemy.gameObject, 0.5f);
                Debug.Log("Enemigo derrotado");
            }
            else
            {
                attackParticle.Play();
                enemy.GetComponent<MainEnemyController>().health -= damage;
                Debug.Log(enemy.GetComponent<MainEnemyController>().health);
            }
        }
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
