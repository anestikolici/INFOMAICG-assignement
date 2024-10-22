using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public bool isFinalEnemy = false;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
{
    Debug.Log(gameObject.name + " has died.");

    // Check if this is the final enemy
    if (isFinalEnemy)
    {
        HUDManager hudManager = FindObjectOfType<HUDManager>();
        if (hudManager != null)
        {
            hudManager.EndGame("You Win!");
        }
        else
        {
            Debug.LogWarning("HUDManager not found in the scene.");
        }
    }

    Destroy(gameObject);
}

}
