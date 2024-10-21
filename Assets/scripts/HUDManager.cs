using UnityEngine;
using UnityEngine.UI;
using TMPro; // Use this if using TextMeshPro

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI healthText; // Reference to the health text
    public TextMeshProUGUI timerText; // Reference to the timer text
    public Image crosshair; // Reference to the crosshair
    public GameObject endPanel; // Reference to the end screen panel

    public float maxTime = 200f; // The time after which the game ends automatically
    private float currentTime = 0f; // Keeps track of the elapsed time
    private bool timerActive = true;
    private PlayerHealth playerHealth;

    void Start()
    {
        // Initialize the player health
        playerHealth = FindObjectOfType<PlayerHealth>(); // Assumes there is only one PlayerHealth in the scene
        UpdateHealthText();
    }

    void Update()
    {
        // Update the timer if it's active
        if (timerActive)
        {
            currentTime += Time.deltaTime; // Increment the time
            timerText.text = "Time: " + currentTime.ToString("F0"); // Display time as an integer

            // Optionally, if you want the timer to end after maxTime:
            if (currentTime >= maxTime)
            {
                EndGame("Time's Up!");
            }
        }

        // Update health in case it changes
        if (playerHealth != null)
        {
            UpdateHealthText();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + playerHealth.GetCurrentHealth().ToString("F0");
    }

    public void EndGame(string message)
    {
        timerActive = false; // Stop the timer
        endPanel.SetActive(true); // Show the end panel
        TextMeshProUGUI endText = endPanel.GetComponentInChildren<TextMeshProUGUI>();
        if (endText != null)
        {
            endText.text = message;
        }
    }
}
