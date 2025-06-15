using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;     // Assign your bullet prefab
    public Transform firePoint;         // Create a child transform at the muzzle
    public float shootInterval = 2f;    // Interval between shots
    public float bulletSpeed = 20f;     // Bullet travel speed

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        InvokeRepeating(nameof(Shoot), 1f, shootInterval);
    }

    void Shoot()
    {
        if (player == null || bulletPrefab == null || firePoint == null) return;

        Vector3 direction = (player.position - firePoint.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }
}
