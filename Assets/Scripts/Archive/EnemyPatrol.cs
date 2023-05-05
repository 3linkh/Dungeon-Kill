using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class EnemyPatrol : MonoBehaviour
{
    [Tooltip("The speed at which the enemy moves.")]
    public float moveSpeed = 5f;

    [Tooltip("The points that the enemy will patrol between.")]
    public Transform[] patrolPoints;

    [Tooltip("The radius of the gizmo path.")]
    public float pathRadius = 1f;

    private int currentPointIndex = 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        if (patrolPoints.Length == 0)
        {
            return;
        }

        Transform currentPoint = patrolPoints[currentPointIndex];
        Vector3 direction = currentPoint.position - transform.position;
        direction.y = 0f;
        direction.Normalize();
        Vector3 targetPosition = currentPoint.position - direction * pathRadius;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            Gizmos.DrawSphere(patrolPoints[i].position, 0.2f);
            if (i < patrolPoints.Length - 1)
            {
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i + 1].position);
            }
            else
            {
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[0].position);
            }
        }
    }
}