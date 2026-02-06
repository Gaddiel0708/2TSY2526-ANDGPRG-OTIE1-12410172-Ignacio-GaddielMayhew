using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip deathClip;
    public AudioClip powerUpClip;
    public AudioClip goalClip;

    // Call this function when the player hits an enemy/obstacle
    public void PlayDeathSound()
    {
        sfxSource.PlayOneShot(deathClip);
    }

    // Call this when the level is finished
    public void PlayGoalSound()
    {
        sfxSource.PlayOneShot(goalClip);
    }
}