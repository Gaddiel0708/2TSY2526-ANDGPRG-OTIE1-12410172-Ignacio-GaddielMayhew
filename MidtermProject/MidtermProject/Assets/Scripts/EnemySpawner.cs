using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float interval = 2f;

    void Start()
    {
        // Starts spawning enemies every 'interval' seconds
        InvokeRepeating("Spawn", 1f, interval);
    }

    void Spawn()
    {
        // Requirement: Instantiation
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    // New function to stop the spawning
    public void StopSpawning()
    {
        CancelInvoke("Spawn");
    }
}