using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    public int enemyMaxHealth;

    public Transform enemyPos;
    public PlayerHealth Health;
    public GameObject weapon;
    public GameObject gun;

    public int damage;
    public int totalDamage;

    public bool item = false;

    void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    void Update()
    {
        // if(enemyHealth <= 0)
        // {
        //     Destroy(this.gameObject);
        //     DropLoot();
        //     Debug.Log("text");
        // }

    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }

    void OnCollisionEnter(Collision other)
    {
       // if (other.gameObject.CompareTag("bullet"))
       // {
        //    enemyHealth -= 10;
        //}
       if(other.gameObject.CompareTag("Player"))
        {

            if (Health.playerHealth <= 1)
            {
               damage = 0;
               Debug.Log("Dead player");
               // SceneManager.LoadScene(0);
            }
            
            
        }
    }

        void OnCollisionExit (Collision other)
    {

       if(other.gameObject.CompareTag("Player"))
        {
            Health.playerHealth +=10; 
        }
    }


    // void DropLoot()
    // {

    //     GameObject instance = Instantiate(weapon, enemyPos.position, Quaternion.identity);
    //     gun = instance.GetComponent<GameObject>();
    //     if (Input.GetKeyDown("e"))
    //     {
    //         Destroy(instance);
    //     }
    //     item = true;

    // }

}
