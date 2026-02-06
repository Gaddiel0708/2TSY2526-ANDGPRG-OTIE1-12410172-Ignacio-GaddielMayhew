using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Drag your Bullet Prefab here
    public Transform firePoint;     // A point at the front of the ship
    public float fireRate = 2f;     // Seconds between shots
    private float nextFireTime;

    private Transform player;

    void Start()
    {
        // Find the player automatically using their Tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        // 1. Look at the player
        transform.LookAt(player);

        // 2. Shoot on a timer
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Create the bullet at the fire point's position and rotation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}