using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [Tooltip("The range of the player's attack.")]
    public float attackRange = 1f;

    [Tooltip("The amount of damage dealt to enemies.")]
    public int damageAmount = 10;

    [Tooltip("The offset from the target's position to look at.")]
    public Vector3 lookAtOffset = new Vector3(0f, 1f, 0f);

    private Animator animator;
    private CharacterController controller;
    private Transform target;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            target = InteractWithCombat();
            animator.SetBool("isAttacking", target != null);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
        LookAtTarget();
    }

    public Transform InteractWithCombat()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
        foreach (RaycastHit hit in hits)
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                continue;
            }

            return target.transform;
        }
        return null;
    }

    Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    public void DealDamage()
    {
        if (target != null)
        {
            EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
    }

    public void LookAtTarget()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + lookAtOffset;
            Vector3 lookAtDirection = targetPosition - transform.position;
            lookAtDirection.y = 0f;
            transform.rotation = Quaternion.LookRotation(lookAtDirection);
        }
        else 
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
             transform.rotation = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        }
    }
}