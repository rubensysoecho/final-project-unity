using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int levelPoints = 0;
    public int lives = 3;
    public int health;
    public int maxHealth;
    public Transform spawnPoint;
    public PlayerController player;
    public float timeToRespawn = 2f;
    private float timer = 0;

    public bool canWallJump;
    public bool canDash;

    public UI_GameOver gameOver;
    public UI_LevelFinished levelFinished;

    public PlayfabManager bbddManager;

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
                else if (lives <= 0)
                {
                    GameOver();
                }
            }
            
        }
    }

    public void Spawn()
    {
        player.transform.position = spawnPoint.transform.position;
    }

    public void FinishLevel()
    {
        Time.timeScale = 0;
        levelFinished.Setup(levelPoints);
        AddPoints(levelPoints);
        int totalPoints = PlayerPrefs.GetInt("totalPoints");
        bbddManager.SendLeaderboard(totalPoints);
        Debug.Log("LEVEL FINISHED!!");
    }

    private void AddPoints(int pointsToAdd)
    {
        int totalPoints = PlayerPrefs.GetInt("totalPoints");
        totalPoints += pointsToAdd;
        PlayerPrefs.SetInt("totalPoints", totalPoints);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        player.isAlive = false;
        gameOver.Setup(levelPoints);
    }

}
