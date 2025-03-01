using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
    }

    private void OnPlayClicked()
    {
        ViewManager.Show<KartSelectionView>();
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }
}
