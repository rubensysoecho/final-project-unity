using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("Velocidad")]
    public float speed = 5f;
    public float runningSpeed = 1f;

    [Header("Salto")]
    public int actualJumps;
    public int maxJumps;
    public float jumpHeight;
    public float maxJumpHeight;
    public bool hardFall;
    private float airIndex;

    [Header("Otros")]
    public bool hasFallen;
    public bool isAttacking;
    public bool isAlive = true;
    public bool isDefending;

    [Header("Referencias")]
    public Rigidbody2D rb;
    public GameManager manager;
    public PlayerMovement movement;
    public Animator anim;

    void Start()
    {
        actualJumps = maxJumps;
        rb = movement.rb;
    }

    void Update()
    {
        airIndex = rb.velocity.y;

        anim.SetBool("Grounded", movement.m_Grounded);
        anim.SetBool("isAlive", isAlive);
        anim.SetBool("hardFall", hardFall);

        hasFallen = AnimationPlaying("fall");

        if (AnimationPlaying("attack01") || AnimationPlaying("attack02") || AnimationPlaying("attack03"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        // Salto del personaje
        Jump();

        if (movement.m_Grounded)
        {
            //actualJumps = maxJumps;
            jumpHeight = 0f;
            hardFall = false;
        }

        if (jumpHeight > maxJumpHeight)
        {
            hardFall = true;
        }

        // Asignar trigger caida salto
        if (airIndex <= 0 && !movement.m_Grounded)
        {
            anim.SetTrigger("Falling");
            jumpHeight += Time.deltaTime;
        }
        else
        {
            anim.ResetTrigger("Falling");
        }

        // Comprobar movimiento y determinar si está corriendo
        if (movement.horizontalInput == 0)
        {
            anim.SetBool("Move", false);
        }
        else if (movement.horizontalInput != 0 && movement.m_Grounded)
        {
            anim.SetBool("Move", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Running", true);
            }
            else
            {
                anim.SetBool("Running", false);
            }
        }   
    }

    void FixedUpdate()
    {
        // Movimiento lateral, CANWALK ELIMINADO
        if (isAlive && !hasFallen && !isAttacking && !isDefending)
        {
            if (anim.GetBool("Running"))
            {
                movement.Move(movement.horizontalInput * (speed * runningSpeed) * Time.deltaTime);
            }
            else
            {
                movement.Move(movement.horizontalInput * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        switch (collision.gameObject.tag)
        {
            case "PointProp":
                manager.levelPoints += 10;
                Destroy(collision.gameObject);
                break;
            case "HealthProp":
                if (manager.health < manager.maxHealth)
                {
                    manager.health += 20;
                }
                Destroy(collision.gameObject);
                break;
            case "CheckPoint":
                manager.spawnPoint = collision.gameObject.transform;
                Debug.Log("checkpoint");
                break;
            case "LevelEnd":
                manager.FinishLevel();
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Level01":
                        PlayerPrefs.SetInt("lvl_completados", 1);
                        break;
                    case "Level02":
                        PlayerPrefs.SetInt("lvl_completados", 2);
                        break;
                }
                break;
            case "EndZone":
                if (manager.lives - 1 <= 0)
                {
                    manager.GameOver();
                }
                else
                {
                    manager.Spawn();
                    manager.lives--;
                    manager.health = manager.maxHealth;
                }
                break;
            case "Capybara":
                manager.levelPoints += 500;
                manager.Spawn();
                Destroy(collision.gameObject, 0);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Spikes":
                anim.SetTrigger("Hit");
                Die();
                break;
            case "WeakPoint":
                Debug.Log("HIT");
                Destroy(collision.transform.parent.gameObject);
                break;
            case "Walker":
                MainEnemyController enemy = collision.gameObject.GetComponent<MainEnemyController>();
                if (manager.health - enemy.damage <= 0)
                {
                    Die();
                }
                else
                {
                    if (!isDefending)
                    {
                        TakeDamage(enemy.damage);
                    }
                    else
                    {
                        Empujar();
                    }
                }
                break;
            case "Eagle":
                EagleController enemyEagle = collision.gameObject.GetComponent<EagleController>();
                if (manager.health - enemyEagle.damage <= 0)
                {
                    Die();
                }
                else
                {
                    if (!isDefending)
                    {
                        TakeDamage(enemyEagle.damage);
                    }
                    else
                    {
                        Empujar();
                    }
                }
                break;
        }
    }

    private void Jump()
    {
        if (
            ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && isAlive && actualJumps > 0)
            ||
            ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && isAlive && movement.isWallSliding && manager.canWallJump)
           )
        {
            movement.Jump();
            anim.SetTrigger("Jump");
            actualJumps--;
        }
        else
        {
            anim.ResetTrigger("Jump");
        }

        if (movement.m_Grounded) 
        {
            actualJumps = maxJumps;
        }
    }
    
    public void Die()
    {
        manager.health = 0;
        rb.bodyType = RigidbodyType2D.Static;
        this.isAlive = false;
        Debug.Log("Has sido derrotado");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Hit");
        manager.health -= damage;
        Empujar();
    }

    private void Empujar()
    {
        if (movement.m_FacingRight)
        {
            rb.velocity = new Vector2(-10, 5);
        }
        else
        {
            rb.velocity = new Vector2(10, 5);
        }
    }

    private bool AnimationPlaying(string animationName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            rb.velocity = Vector2.zero;
            return true;
        }
        return false;
    }
}
