using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinView : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlayWinSFX();
    }

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("GameScene"); // SceneManager will now auto-restart Game BGM
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
