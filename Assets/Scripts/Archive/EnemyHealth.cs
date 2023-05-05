using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [Tooltip("The scriptable object containing the enemy's health.")]
    [SerializeField] EnemyCharacter enemyCharacterSO;

    public float currentHealth;

    public bool isDead = false;

    private void Start()
    {
        currentHealth = enemyCharacterSO.currentHealth;
    }

    /// <summary>
    /// Returns the current health of the enemy.
    /// </summary>
    /// <returns>The current health of the enemy.</returns>
    public float GetHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Reduces the enemy's health by the specified amount.
    /// </summary>
    /// <param name="damage">The amount of damage to be dealt.</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO: Implement death behavior.
    }
}