using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int playerMaxHealth;

    public Text playerHealthTXT;

    bool beingHit = false;

    public float damageDelay;
    private float time;

    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    void Update()
    {
        playerHealthTXT.text = playerHealth.ToString();

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

        if(beingHit && time >= damageDelay) 
        {
            playerHealth -= 1; 
            time = 0;
        }

        if(beingHit)
        {
            time = time + 1f * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            beingHit = true;
        }

        if (other.gameObject.CompareTag("ResetLvl"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            beingHit = false;
        }
    }
}
