using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class WinManager : MonoBehaviour
{
    [Header("Level Goals")]
    public int enemiesToWin = 5;
    public int maxEnemiesAllowed = 50;

    private int currentKills = 0;
    private bool isGameOver = false; // Prevents the Game Over from triggering multiple times
    public TextMeshPro countText;

    [Header("Audio Settings")]
    public AudioSource winSound;
    public AudioSource loseSound; // NEW: Drag your losing sound here
    public AudioSource backgroundMusic;

    [Header("Spawner Reference")]
    public EnemySpawner spawner;

    void Update()
    {
        if (isGameOver) return; // Stop checking if we already lost

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (totalEnemies.Length >= maxEnemiesAllowed)
        {
            StartCoroutine(GameOverSequence());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // FIX: Only count the kill if the level hasn't ended yet
        if (other.CompareTag("Enemy") && !isGameOver)
        {
            currentKills++;
            Destroy(other.gameObject);
            UpdateUI();

            if (currentKills >= enemiesToWin)
            {
                StartCoroutine(WinSequence());
            }
        }
        // Optional: If you still want the enemies to disappear but NOT count
        else if (other.CompareTag("Enemy") && isGameOver)
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator WinSequence()
    {
        isGameOver = true; // Block other triggers
        if (spawner != null) spawner.StopSpawning();
        if (backgroundMusic != null) backgroundMusic.Stop();

        if (winSound != null) winSound.Play();
        if (countText != null) countText.text = "LEVEL CLEAR!";

        float waitTime = winSound != null ? winSound.clip.length : 2.0f;
        yield return new WaitForSeconds(waitTime);

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            if (countText != null) countText.text = "YOU WIN THE GAME!";
        }
    }

    IEnumerator GameOverSequence()
    {
        isGameOver = true; // Prevents looping
        if (spawner != null) spawner.StopSpawning();
        if (backgroundMusic != null) backgroundMusic.Stop();

        // Play the loss audio
        if (loseSound != null) loseSound.Play();

        if (countText != null)
        {
            countText.text = "TOO MANY ENEMIES! GAME OVER";
            countText.color = Color.red;
        }

        // Wait for the loss sound to finish or a set time
        float waitTime = loseSound != null ? loseSound.clip.length : 3.0f;
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateUI()
    {
        if (countText != null)
        {
            countText.text = "Killed: " + currentKills + " / " + enemiesToWin;
        }
    }
}