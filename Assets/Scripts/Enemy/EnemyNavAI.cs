using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyNavAI : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private Vector3 wanderTarget;
    private Vector3 origin;

    private float targetDistance;

    private bool wasChasing = false;

    public float agroRange;
    public float wanderRadius = 15f;
    public float wanderInterval = 5f;
    public float defaultSpeed = 2.5f;
    public float distanceFromPlayer;

    private float wanderTimer;
    private float curStoppingDistance;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindFirstObjectByType<PlayerController>().GetComponent<Transform>();
        origin = transform.position;
        curStoppingDistance = agent.stoppingDistance;

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
            wasChasing = true;
            agent.stoppingDistance = distanceFromPlayer;
            ChasePlayer();
        }

        else
        {
            if (wasChasing)
            {
                wasChasing = false;
                agent.stoppingDistance = curStoppingDistance;
                PickNewWanderTarget();
            }

            Wander();
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
    }
}
