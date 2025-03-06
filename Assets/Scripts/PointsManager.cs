using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;  // Singleton to access from other scripts
    public TextMeshProUGUI pointsText;     // Reference to the text UI
    private int currentPoints = 0;         // Track current points

    private void Awake()
    {
        // Singleton pattern to ensure only one PointsManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdatePointsText();
    }

    // Method to add points
    public void AddPoints(int points)
    {
        currentPoints += points;
        UpdatePointsText();
    }

    // Update the text UI
    private void UpdatePointsText()
    {
        pointsText.text = "Points: " + currentPoints;
    }
}
