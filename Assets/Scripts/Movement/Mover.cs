using UnityEngine;
using UnityEngine.AI;


    public class Mover : MonoBehaviour, IAction
    {
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed = 6f;

    NavMeshAgent navMeshAgent;
    Health health;

    private void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        navMeshAgent.enabled = !health.IsDead();

        UpdateAnimator();
    }
    
    public void StartMoveAction(Vector3 destination, float speedFraction)
    {
        GetComponent<ActionScheduler>().StartAction(this);
        MoveTo(destination, speedFraction);
    }

    public void MoveTo(Vector3 destination, float speedFraction)
    {
        navMeshAgent.destination = destination;
        navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
        navMeshAgent.isStopped = false;
    }

    public void Cancel()
    {
        navMeshAgent.isStopped = true;
    }
    
    private void UpdateAnimator()
    {
        Vector3 velocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        float animatorSpeedFraction = speed/1;
        
        GetComponent<Animator>().SetFloat("forwardSpeed", animatorSpeedFraction);
        
        if (localVelocity != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);

        }
        

    }
    }

    //     public object CaptureState()
    //     {
    //         return new SerializableVector3(transform.position);
    //     }

    //     public void RestoreState(object state)
    //     {
    //         SerializableVector3 position = (SerializableVector3)state;
    //         GetComponent<NavMeshAgent>().enabled = false;
    //         transform.position = position.ToVector();
    //         GetComponent<NavMeshAgent>().enabled = true;
    //     }
    // }

