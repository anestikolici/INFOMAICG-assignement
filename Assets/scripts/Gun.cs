using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;

    public Vector3 recoilAmount = new Vector3(0f, 0.1f, -0.1f); // Amount of recoil on each axis
    public float recoilSpeed = 5f; // Speed of returning to original position

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition; // Store the initial position of the gun
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            ApplyRecoil();
        }

        // Smoothly return the gun back to its original position
        transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * recoilSpeed);
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    void ApplyRecoil()
    {
        // Apply a small offset for recoil
        transform.localPosition += recoilAmount;
    }
}
