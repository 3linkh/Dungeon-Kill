using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [Tooltip("The health component of the player")]
    [SerializeField] private Health playerHealth;

    [Tooltip("The text component displaying the player's health")]
    [SerializeField] private TextMeshProUGUI playerHealthText;

    [Tooltip("The slider component displaying the player's health")]
    [SerializeField] private Slider playerHealthSlider;

    private float maxHealth;

    private void Start()
    {
        maxHealth = playerHealth.healthPoints;
    }

    private void Update()
    {
        playerHealthText.text = "Player Health: " + playerHealth.healthPoints;

        // Calculate the percentage of player health and set the slider value accordingly
        float healthPercentage = playerHealth.healthPoints / maxHealth;
        playerHealthSlider.value = 1 - healthPercentage;
    }
}