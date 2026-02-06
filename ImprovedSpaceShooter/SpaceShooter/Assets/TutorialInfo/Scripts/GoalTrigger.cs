using UnityEngine;
using TMPro;

public class GoalTrigger : MonoBehaviour
{
    public AudioClip goalClip;
    public GameObject victoryText;
    public AudioSource bgmSource; // Drag your MusicManager's AudioSource here

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Stop the Background Music
            if (bgmSource != null)
            {
                bgmSource.Stop();
            }

            // 2. Play the Victory Sound
            AudioSource.PlayClipAtPoint(goalClip, transform.position);

            // 3. Show the Victory Text
            if (victoryText != null)
            {
                victoryText.SetActive(true);
            }

            // 4. Disable player movement (optional)
            other.GetComponent<MonoBehaviour>().enabled = false;

            Debug.Log("Goal Reached and Music Stopped!");
        }
    }
}