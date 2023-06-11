using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Variables del jugador")]
    public int levelPoints = 0;
    public int lives = 3;
    public int health;
    public int maxHealth;
    public float timeToRespawn = 2f;

    [Header("Otros")]
    public bool canWallJump;
    public bool canDash;

    [Header("Referencias")]
    public PlayerController player;
    public Transform spawnPoint;
    public UI_GameOver gameOver;
    public UI_LevelFinished levelFinished;
    public PlayfabManager bbddManager;

    private float timer = 0;
    private bool dataSent;

    void Start()
    {
        Spawn();
        health = maxHealth;
        Time.timeScale = 1f;
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
        if (!dataSent)
        {
            Time.timeScale = 0;
            levelFinished.Setup(levelPoints);
            AddPoints(levelPoints);
            int totalPoints = PlayerPrefs.GetInt("totalPoints");
            bbddManager.SendLeaderboard(totalPoints);
            Debug.Log("LEVEL FINISHED!!");
            dataSent = true;
        }
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
