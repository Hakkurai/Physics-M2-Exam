using UnityEngine;
using UnityEngine.UI;

public class KartSelectionView : View
{
    [SerializeField] private Button kart1Button;
    [SerializeField] private Button kart2Button;
    [SerializeField] private Button kart3Button;
    [SerializeField] private Button backButton;

    private void Start()
    {
        kart1Button.onClick.AddListener(() => SelectKart(1));
        kart2Button.onClick.AddListener(() => SelectKart(2));
        kart3Button.onClick.AddListener(() => SelectKart(3));
        backButton.onClick.AddListener(ViewManager.ShowLast);
    }

    private void SelectKart(int kartIndex)
    {
        Debug.Log("Selected Kart: " + kartIndex);
        // Load Game Scene (Example)
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
