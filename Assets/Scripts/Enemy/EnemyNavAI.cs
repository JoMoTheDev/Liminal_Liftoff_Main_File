using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyNavAI : MonoBehaviour
{
    public Animator animator;

    public Transform enemyPlacement;
    private Transform target;
    private NavMeshAgent agent;
    private Vector3 wanderTarget;

    public string initialAnimation = "Breath_Gumbo";
    public string entranceAnimation;

    public bool shouldWander;
    private bool wasChasing = false;
    private bool isWalking;
    private bool entrancePlaying;
    private bool entranceHasPlayed;

    public float agroRange;
    public float wanderRadius = 15f;
    public float wanderInterval = 5f;
    public float defaultSpeed = 2.5f;
    public float distanceFromPlayer;
    public float entranceLength = 5f;
    private float targetDistance;

    private float wanderTimer;
    private float curStoppingDistance;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindFirstObjectByType<PlayerController>().GetComponent<Transform>();
        curStoppingDistance = agent.stoppingDistance;

        animator.Play(initialAnimation);

        wanderTimer = wanderInterval;
        agent.speed = defaultSpeed;
    }

    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance <= agroRange)
        {
            if (entranceAnimation != null && !entranceHasPlayed && !entrancePlaying)
            {
                StartCoroutine(EntranceAnimation());
            }
            else if (entranceHasPlayed)
            {
                wasChasing = true;
                agent.stoppingDistance = distanceFromPlayer;
                ChasePlayer();
                if (!isWalking)
                {
                    isWalking = true;
                    animator.Play("Walk_Gumbo");
                }
            }
        }

        else
        {
            if (wasChasing)
            {
                wasChasing = false;
                agent.stoppingDistance = curStoppingDistance;
                PickNewWanderTarget();
                isWalking = false;
                animator.Play("Breath_Gumbo");
            }

            if (shouldWander)
            {
                Wander();
            }
        }
    }

    void PickNewWanderTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position; // Offset from AI's current position

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
        {
            wanderTarget = hit.position; // Assign a valid NavMesh position
            agent.SetDestination(wanderTarget);
        }

        wanderTimer = wanderInterval; // Reset timer
    }

    void ChasePlayer()
    {
        agent.SetDestination(target.position);
    }

    void Wander()
    {
        wanderTimer -= Time.deltaTime;

        if (wanderTimer <= 0f || agent.remainingDistance < 0.5f) // Pick new target if timer runs out or destination reached
        {
            PickNewWanderTarget();
        }
    }

    IEnumerator EntranceAnimation()
    {
        entrancePlaying = true;
        animator.Play(entranceAnimation);
        yield return new WaitForSeconds(entranceLength);
        if (enemyPlacement != null)
        {
            gameObject.transform.position = enemyPlacement.position;
        }
        agent.enabled = true;
        entranceHasPlayed = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
    }
}
