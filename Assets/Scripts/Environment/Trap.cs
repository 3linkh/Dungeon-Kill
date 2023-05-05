using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trap : MonoBehaviour
{
    [Tooltip("Amount of damage to inflict on player.")]
    public float damageAmount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // Get the health component of the player
            PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();

            // If the player has a health component, damage them
            if (playerhealth != null)
            {
                playerhealth.TakeDamage(damageAmount);
            }
        }
    }
}