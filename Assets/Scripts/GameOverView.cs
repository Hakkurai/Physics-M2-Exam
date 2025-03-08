using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverView : MonoBehaviour
{
    // Called when the Retry button is clicked
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("GameScene");  // Replace with your actual game scene name
    }

    // Called when the Main Menu button is clicked
    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");  // Replace with your actual main menu scene name
    }
}
