using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;  
    public TextMeshProUGUI pointsText;     
    private int currentPoints = 0;         

    private void Awake()
    {
        
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

    public void AddPoints(int points)
    {
        currentPoints += points;
        UpdatePointsText();
    }
    
    private void UpdatePointsText()
    {
        pointsText.text = "" + currentPoints;
    }
}
