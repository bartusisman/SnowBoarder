using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public TextMeshProUGUI speedText; // Reference to the TextMeshProUGUI element
    public PlayerController playerController; // Reference to the PlayerController script

    void Update()
    {
        if (playerController != null && speedText != null)
        {
            // Calculate the current speed of the player
            float currentSpeed = playerController.GetCurrentSpeed();
            // Update the text element with the current speed
            speedText.text = "Speed: " + currentSpeed.ToString("F2");
        }
    }
}
