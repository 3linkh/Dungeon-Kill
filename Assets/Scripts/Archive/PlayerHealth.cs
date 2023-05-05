using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerHealth : MonoBehaviour
{
    [Tooltip("The maximum health of the player.")]
    public float maxHealth = 100f;

    [Tooltip("The current health of the player.")]
    public float currentHealth = 100f;

    [Tooltip("The amount of health the player gains when using a health consumable.")]
    public float healthGainAmount = 20f;

    [Tooltip("The amount of health the player loses when taking damage.")]
    public float damageAmount = 10f;

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Enemy") || other.CompareTag("Hazard") || other.CompareTag("Trap") || other.CompareTag("Spell"))
    //     {
    //         //TakeDamage(damageAmount);
    //     }
    //     else if (other.CompareTag("Consumable"))
    //     {
    //         GainHealth();
    //     }
    // }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void GainHealth()
    {
        currentHealth += healthGainAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        // TODO: Implement player death logic
    }
}