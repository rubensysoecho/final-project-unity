using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemyController : MonoBehaviour
{
    public int health;
    public int damage;
    public int reward;
    public ParticleSystem executionParticle;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Die()
    {
        Destroy(this, 0);
    }
}
