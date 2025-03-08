using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuView : View
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(() => { AudioManager.Instance.PlayButtonSFX(); OnPlayClicked(); });
        quitButton.onClick.AddListener(() => { AudioManager.Instance.PlayButtonSFX(); OnQuitClicked(); });

        AddHoverEvents(playButton);
        AddHoverEvents(quitButton);
    }

    private void OnPlayClicked()
    {
        ViewManager.Show<KartSelectionView>();
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }

    private void AddHoverEvents(Button button)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerEnter = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
        pointerEnter.callback.AddListener((data) => AudioManager.Instance.PlayButtonSFX());

        trigger.triggers.Add(pointerEnter);
    }
}
