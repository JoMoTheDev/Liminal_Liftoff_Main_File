using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        print(currentHealth);

        if(currentHealth <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
}
