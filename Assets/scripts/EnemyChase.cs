using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float minSpeed = 10f; // Minimum speed of the enemy
    public float maxSpeed = 15f; // Maximum speed of the enemy
    public float damage = 10f; // Amount of damage the enemy deals upon collision
    public float damageInterval = 1f; // Time interval between damage applications

    private float speed; // Actual speed of the enemy
    private float nextDamageTime = 0f; // Timer to track when the enemy can damage the player again

    void Start()
    {
        // Set a random speed for this enemy between minSpeed and maxSpeed
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if (player == null) return;

        // Move towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Optional: Make the enemy face the player as it moves
        transform.LookAt(player);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Attempt to damage the player when first colliding
            TryToDamagePlayer(collision.gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Continue to damage the player if the enemy stays in contact with them
        if (collision.gameObject.CompareTag("Player"))
        {
            TryToDamagePlayer(collision.gameObject);
        }
    }

    void TryToDamagePlayer(GameObject playerObject)
    {
        // Check if enough time has passed to damage the player again
        if (Time.time >= nextDamageTime)
        {
            PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                nextDamageTime = Time.time + damageInterval; // Set the time for the next allowed damage
            }
        }
    }
}
