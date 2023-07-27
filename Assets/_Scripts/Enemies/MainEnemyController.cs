using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemyController : MonoBehaviour
{
    [Header("Variables del enemigo")]
    public int health;
    public int damage;
    public int reward;

    [Header("Referencias")]
    public ParticleSystem executionParticle;

    public void ReceiveDamage(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        Destroy(this, 0);
    }
}
