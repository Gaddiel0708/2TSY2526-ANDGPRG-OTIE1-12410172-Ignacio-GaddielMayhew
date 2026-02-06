using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] nozzles;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;

    [Header("Audio Settings")]
    public AudioSource sfxSource;
    public AudioClip shootSFX;
    public AudioClip deathSFX; // Requirement: Death SFX

    private int activeNozzleIndex = 0;
    private float nextFireTime;

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Switching Nozzles
        if (keyboard.digit1Key.wasPressedThisFrame && nozzles.Length > 0) activeNozzleIndex = 0;
        if (keyboard.digit2Key.wasPressedThisFrame && nozzles.Length > 1) activeNozzleIndex = 1;
        if (keyboard.digit3Key.wasPressedThisFrame && nozzles.Length > 2) activeNozzleIndex = 2;
        if (keyboard.digit4Key.wasPressedThisFrame && nozzles.Length > 3) activeNozzleIndex = 3;

        // Shooting
        if (keyboard.spaceKey.isPressed && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (activeNozzleIndex < nozzles.Length && nozzles[activeNozzleIndex] != null && bulletPrefab != null)
        {
            Instantiate(bulletPrefab, nozzles[activeNozzleIndex].position, nozzles[activeNozzleIndex].rotation);

            // Play Trigger SFX
            if (sfxSource && shootSFX) sfxSource.PlayOneShot(shootSFX);
        }
        else
        {
            Debug.LogWarning("Missing Nozzle or Bullet Prefab in Inspector!");
        }
    }

    // Call this when your health reaches 0
    public void OnPlayerDeath()
    {
        if (sfxSource && deathSFX) sfxSource.PlayOneShot(deathSFX);
    }
}