using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the player
    private float currentHealth;

    void Start()
    {
        // Initialize player's health to maximum at the start of the game
        currentHealth = maxHealth;
    }

    // Method to reduce the player's health
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player took " + damageAmount + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    // Method to handle player's death
    void Die()
    {
        Debug.Log("Player has died!");
        // Add death handling here (e.g., respawn, restart the level, show game over screen)
        // For now, we will just destroy the player object.
        Destroy(gameObject);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
