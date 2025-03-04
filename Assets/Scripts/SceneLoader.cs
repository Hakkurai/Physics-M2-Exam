using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Method for Retry button
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Method for Main Menu button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Method for Quit button (if you plan to add it)
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // Works only in the built version, not in the editor
    }
}
