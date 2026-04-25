using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;

    public int attackDamage = 10;
    public float attackRange = 2.5f;
    public float attackRate = 2f; // Attack every X seconds
    private float nextAttackTime = 1f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerHealth>().transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            Attack();
        }
    }

    void Attack()
    {
        Vector3 direction = (transform.TransformDirection(Vector3.forward));

        RaycastHit hit;

        Debug.DrawRay(transform.position, direction * attackRange, Color.blue, 1.0f);

        animator.Play("Attack_Gumbo");

        if (Physics.Raycast(transform.position, direction, out hit, attackRange))
        {
            if (hit.transform.gameObject.GetComponent<PlayerHealth>())
            {
                hit.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }

        nextAttackTime = Time.time + attackRate;
    }
}
