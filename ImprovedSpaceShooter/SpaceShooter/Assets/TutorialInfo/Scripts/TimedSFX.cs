using UnityEngine;
using System.Collections; // Required for Coroutines

public class TimedSFX : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip powerUpReadyClip;
    public float delaySeconds = 30f;

    void Start()
    {
        // Start the timer as soon as the level begins
        StartCoroutine(PlaySoundAfterDelay());
    }

    IEnumerator PlaySoundAfterDelay()
    {
        Debug.Log("Timer started... waiting for " + delaySeconds + " seconds.");

        // This line tells Unity to wait
        yield return new WaitForSeconds(delaySeconds);

        // Play the sound
        if (sfxSource != null && powerUpReadyClip != null)
        {
            sfxSource.PlayOneShot(powerUpReadyClip);
            Debug.Log("30 Seconds up! Power-up SFX played.");
        }
    }
}