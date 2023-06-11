using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Variables de combate")]
    public float attackRange = 0.5f;
    private int damage;
    public LayerMask enemyLayers;
    public int pullForce;
    public float defenseTime;
    public float defendingTime;

    [Header("Referencias")]
    public ParticleSystem attackParticle;
    public PlayerController controller;
    public PlayerMovement movement;
    public Animator anim;
    public GameManager manager;
    public Transform attackPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !controller.isAttacking && movement.m_Grounded)
        {
            Attack01();
        }

        if (Input.GetKeyDown(KeyCode.X) && !controller.isAttacking && movement.m_Grounded)
        {
            Attack02();
        }
        
        if (Input.GetKeyDown(KeyCode.C) && !controller.isAttacking && movement.m_Grounded)
        {
            Attack03();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Defend();
        }

        if (controller.isDefending)
        {
            defendingTime += Time.deltaTime;
            if (defendingTime >= defenseTime)
            {
                defendingTime = 0;
                controller.isDefending = false;
                anim.SetBool("isDefending", false);
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
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
                manager.levelPoints = manager.levelPoints + enemy.gameObject.GetComponent<MainEnemyController>().reward;
                Destroy(enemy.gameObject, 0.5f);
                Debug.Log("Enemigo derrotado");
            }
            else
            {
                Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
                attackParticle.Play();
                enemy.GetComponent<MainEnemyController>().ReceiveDamage(damage);
                Empujar(enemyRb);
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
                manager.levelPoints = manager.levelPoints + enemy.gameObject.GetComponent<MainEnemyController>().reward;
                Destroy(enemy.gameObject, 0.5f);
                Debug.Log("Enemigo derrotado");
            }
            else
            {
                Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
                attackParticle.Play();
                enemy.GetComponent<MainEnemyController>().ReceiveDamage(damage);
                Empujar(enemyRb);
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
                manager.levelPoints = manager.levelPoints + enemy.gameObject.GetComponent<MainEnemyController>().reward;
                Destroy(enemy.gameObject, 0.5f);
                Debug.Log("Enemigo derrotado");
            }
            else
            {
                Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
                attackParticle.Play();
                enemy.GetComponent<MainEnemyController>().ReceiveDamage(damage);
                Empujar(enemyRb);
            }
        }
    }

    private void Defend()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        controller.isDefending = true;
        anim.SetBool("isDefending", true);
    }

    private void Empujar(Rigidbody2D enemyRb)
    {
        if (movement.m_FacingRight)
        {
            enemyRb.velocity = new Vector2(pullForce, 3);
        }
        else
        {
            enemyRb.velocity = new Vector2(-pullForce, 3);
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
