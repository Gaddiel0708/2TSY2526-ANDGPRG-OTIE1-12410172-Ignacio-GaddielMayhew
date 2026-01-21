using UnityEngine;
using TMPro;

public class PlanetInfo : MonoBehaviour
{
    public string planetName;
    public GameObject uiText;

    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if the thing that touched the planet is the Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is near: " + planetName);

            // 2. Turn the UI object ON so it's visible
            uiText.SetActive(true);

            // 3. Set the text to the planet's specific name
            uiText.GetComponent<TMPro.TextMeshProUGUI>().text = planetName;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiText.SetActive(false);
        }
    }
}
