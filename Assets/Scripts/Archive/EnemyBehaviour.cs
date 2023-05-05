using UnityEngine;

// Add required components
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyBehaviour : MonoBehaviour
{
    // Expose properties in the inspector with tooltips
    [Tooltip("The time in seconds the enemy needs to be within range of the player before the child object starts scaling.")]
    public float timeBeforeScaling = 2f;

    [Tooltip("The speed at which the child object scales up and down.")]
    public float scalingSpeed = 1f;

    [Tooltip("The color the child object changes to when within range of the player.")]
    public Color targetColor = Color.red;

    [Tooltip("The speed at which the child object changes color.")]
    public float colorChangeSpeed = 1f;

    [Tooltip("The scriptable object containing the enemy's character stats.")]
    public EnemyCharacter enemyCharacter;

    // Private variables
    private float timeInRange = 0f;
    private bool isInRange = false;
    private Vector3 originalScale;
    private Renderer childRenderer;
    private Color originalColor;
    private Rigidbody rb;
    public PlayerHealth player;
    private Animator animator;

    private void Start()
    {
        // Get the child object's original scale and renderer
        originalScale = transform.GetChild(0).localScale;
        childRenderer = transform.GetChild(0).GetComponent<Renderer>();
        originalColor = childRenderer.material.color;

        // Set the enemy's current health to its maximum health
        enemyCharacter.currentHealth = enemyCharacter.maxHealth;

        // Get the enemy's rigidbody component
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isInRange)
        {
            Attack();
            timeInRange += Time.deltaTime;

            if (timeInRange >= timeBeforeScaling)
            {
                // Scale the child object up and down
                float scale = Mathf.Sin(Time.time * scalingSpeed) * 0.1f + 1f;
                transform.GetChild(0).localScale = originalScale * scale;

                // Change the child object's color
                Color newColor = Color.Lerp(originalColor, targetColor, Mathf.PingPong(Time.time * colorChangeSpeed, 1f));
                childRenderer.material.color = newColor;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            player = other.GetComponent<PlayerHealth>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            timeInRange = 0f;
            transform.GetChild(0).localScale = originalScale;
            childRenderer.material.color = originalColor;
        }
    }

    // Attack behavior method
    public void Attack()
    {
        
        animator.SetBool("isAttacking", true);
        
        

        // Apply a force to the enemy in the opposite direction of the player's position
        Vector3 direction = transform.position - player.transform.position;
        rb.AddForce(direction.normalized * enemyCharacter.speed, ForceMode.Impulse);
    }
    public void DealDamage()
    {
        player.TakeDamage(enemyCharacter.damage);
    }
}