using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100;
    public float maxHealth=100;
    public void reduceHealth(float damage)
    {
        health -= damage;
    }
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}