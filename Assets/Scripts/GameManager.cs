using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalCoins = 0;
    public int lives = 3;
    public float health;
    public float maxHealth;
    public Transform spawnPoint;
    public PlayerController player;
    public float timeToRespawn = 2f;
    private float timer = 0;

    public bool canWallJump;
    public bool canDash;

    void Start()
    {
        Spawn();
        health = maxHealth;
    }

    void Update()
    {
        if (!player.isAlive)
        {
            if (timer < timeToRespawn)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                if (lives > 0)
                {
                    lives--;
                    Vector3 position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, player.transform.position.z);
                    player.transform.position = position;
                    player.isAlive = true;
                    health = maxHealth;
                    timer = 0;
                }
                else
                {
                    Debug.Log("GAME OVER!!");
                }
            }
            
        }
    }

    public void FinishLevel()
    {
        Debug.Log("LEVEL FINISHED!!");
    }

    public void Spawn()
    {
        player.transform.position = spawnPoint.transform.position;
    }
}
