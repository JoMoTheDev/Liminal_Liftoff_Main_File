using System.Collections;
using UnityEditor.Build.Reporting;
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

    private EnemyHealth enemy;

    private void Start()
    {
        playerHealth = playerMaxHealth;
        healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        if (healthSlider == null)
        {
            print("no health slider");
        }
    }

    private void Update()
    {
        if ( healthSlider != null)
        {
            healthSlider.value = playerHealth;
            CheckPLayerHealth();
        }
    }

    void CheckPLayerHealth()
    {
       //HealthNumbers.text = playerHealth.ToString();
       // if (playerHealth <= 0)
        //{
        //    SceneManager.LoadScene(0);
       // }
    }

    void OnCollisionStay(Collision other)
    {
        
        if (other.gameObject.CompareTag("enemy") && canTakeDamage)
        {
            
            //Debug.Log("Enemy is Touching Player");
            touchingEnemy = true;  
            canCo = true;
            if (playerHealth > 1)
            {
                playerHealth -= 1;
                StartCoroutine(DamageDelay());
                print(playerHealth);
            }
        }

    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            touchingEnemy = false;
            canCo = false;
        }
        //playerHealth +=1; 

    }

    IEnumerator DamageDelay()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.1f);
        canTakeDamage = true;
    }
}
