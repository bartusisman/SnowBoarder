using UnityEngine;
using TMPro;

public class SpinCountDisplay : MonoBehaviour
{
    public TextMeshProUGUI spinCountText; // Reference to the TextMeshProUGUI element
    public PlayerController playerController; // Reference to the PlayerController script

    void Update()
    {
        if (playerController != null && spinCountText != null)
        {
            // Get the total spin count from the PlayerController script
            int totalSpinCount = playerController.GetTotalSpinCount();
            // Update the text element with the total spin count
            spinCountText.text = "Total Spins: " + totalSpinCount.ToString();
        }
    }
}
