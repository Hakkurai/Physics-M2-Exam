using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("GameScene");  
    }

    
    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");  
    }
}
