using UnityEngine;
using UnityEngine.InputSystem; // Using the New Input System as seen in your project

public class PlayerShooting : MonoBehaviour
{
    public Transform[] nozzles;        // Nozzle1, Nozzle2, etc.
    public GameObject bulletPrefab;    // The bullet you want to fire
    public float fireRate = 0.2f;

    private int activeNozzleIndex = 0; // Tracks which nozzle is currently "armed"
    private float nextFireTime;

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Check each key individually
        if (keyboard.digit1Key.wasPressedThisFrame)
        {
            activeNozzleIndex = 0;
            Debug.Log("Switched to Nozzle 1");
        }
        else if (keyboard.digit2Key.wasPressedThisFrame)
        {
            activeNozzleIndex = 1;
            Debug.Log("Switched to Nozzle 2");
        }
        else if (keyboard.digit3Key.wasPressedThisFrame)
        {
            activeNozzleIndex = 2;
            Debug.Log("Switched to Nozzle 3");
        }
        else if (keyboard.digit4Key.wasPressedThisFrame)
        {
            activeNozzleIndex = 3;
            Debug.Log("Switched to Nozzle 4");
        }

        // Shooting logic
        if (keyboard.spaceKey.isPressed && Time.time >= nextFireTime)
        {
            FireFromActiveNozzle();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireFromActiveNozzle()
    {
        // 1. Check if the Nozzle exists
        if (activeNozzleIndex >= nozzles.Length || nozzles[activeNozzleIndex] == null)
        {
            Debug.LogError("Nozzle at index " + activeNozzleIndex + " is missing in the Inspector!");
            return;
        }

        // 2. Check if the Bullet exists
        if (bulletPrefab == null)
        {
            Debug.LogError("You forgot to drag a Bullet Prefab into the script in the Inspector!");
            return;
        }

        // 3. Spawn
        Transform targetNozzle = nozzles[activeNozzleIndex];
        Instantiate(bulletPrefab, targetNozzle.position, targetNozzle.rotation);
    }
}