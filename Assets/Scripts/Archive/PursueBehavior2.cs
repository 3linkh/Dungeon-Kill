using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyPatrol))]
public class PursueBehavior2 : MonoBehaviour
{
    [Tooltip("The player game object to pursue.")]
    public GameObject player;

    [Tooltip("The distance at which the enemy will start pursuing the player.")]
    public float pursuitDistance = 10f;

    [Tooltip("The time in seconds the enemy will wait before returning to patrolling behavior.")]
    public float waitTime = 5f;

    private NavMeshAgent agent;
    private EnemyPatrol patrolBehavior;
    private Vector3 originalPosition;
    private bool isPursuing = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolBehavior = GetComponent<EnemyPatrol>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= pursuitDistance)
        {
            isPursuing = true;
            agent.SetDestination(player.transform.position);
            patrolBehavior.enabled = false;
        }
        else if (isPursuing)
        {
            StartCoroutine(WaitAndReturn());
        }
        else
        {
            agent.SetDestination(originalPosition);
            patrolBehavior.enabled = true;
        }
    }
    
    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(waitTime);
        isPursuing = false;
        agent.SetDestination(originalPosition);
        patrolBehavior.enabled = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pursuitDistance);
    }
}