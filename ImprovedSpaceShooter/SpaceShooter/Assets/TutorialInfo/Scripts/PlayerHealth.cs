using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    [Header("Audio Settings")]
    public AudioSource sfxSource;
    public AudioClip regenClip; // Drag your Regen sound here
    public AudioClip deathClip;

    // Call this when picking up a health pack
    public void RegenerateHealth(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;

        // Play the Regen SFX
        if (sfxSource && regenClip)
        {
            sfxSource.PlayOneShot(regenClip);
        }
        Debug.Log("Health Regnerated! Current Health: " + health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    void Die()
    {
        sfxSource.PlayOneShot(deathClip);
        gameObject.SetActive(false);
    }
}