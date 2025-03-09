using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverView : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlayLoseSFX();
    }

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
