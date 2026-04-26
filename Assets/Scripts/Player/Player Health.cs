using System.Collections;
//using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public TMP_Text HealthNumbers;
    public Slider healthSlider;

    public int playerHealth;
    public int playerMaxHealth;

    public int damageTaken;

    public bool touchingEnemy = false;
    public bool canCo = false;

    private bool canTakeDamage = true;

    private void Start()
    {
        playerHealth = playerMaxHealth;
        healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        if (healthSlider == null)
        {
            print("no health slider");
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        UpdateHealthBar();
        if (playerHealth <= 0)
        {
            print("you dead");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            TakeDamage(-playerMaxHealth);
        }
    }

    void UpdateHealthBar()
    {
        healthSlider.value = playerHealth;
    }
}
