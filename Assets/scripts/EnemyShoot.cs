using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject beamPrefab; // Prefab for the beam
    public Transform shootPoint;  // Where the beam spawns from
    public float shootForce = 20f; // Speed of the beam
    public float timeBetweenShots = 2f; // Time between shots
    public float beamLifetime = 5f; // How long the beam lasts before it is destroyed
    public Transform player; // Reference to the player's position

    private float shootTimer;

    void Start()
    {
        shootTimer = timeBetweenShots;
    }

    void Update()
    {
        // Rotate towards the player
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }

        // Shoot at intervals
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            ShootBeam();
            shootTimer = timeBetweenShots;
        }
    }

    void ShootBeam()
    {
        // Instantiate the beam
        GameObject beam = Instantiate(beamPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = beam.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Apply force to the beam
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }

        // Destroy the beam after a certain time
        Destroy(beam, beamLifetime);
    }
}
