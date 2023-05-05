using UnityEngine;


// Create a scriptable object
[CreateAssetMenu(fileName = "NewEnemyCharacter", menuName = "Enemy Character")]
public class EnemyCharacter : ScriptableObject
{
    // Properties with tooltips
    [Tooltip("The maximum health of the enemy.")]
    public float maxHealth = 100f;
    [Tooltip("The speed of the enemy.")]
    public float speed = 5f;
    [Tooltip("The damage the enemy deals to the player.")]
    public float damage = 10f;

    // Private variables
    public float currentHealth;

    
    
}