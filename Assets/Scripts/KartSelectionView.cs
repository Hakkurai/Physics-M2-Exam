using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class KartSelectionView : View
{
    [SerializeField] private Button kart1Button;
    [SerializeField] private Button kart2Button;
    [SerializeField] private Button kart3Button;
    [SerializeField] private Button backButton;

    [SerializeField] private GameObject[] kartPreviews; // Assign the 3D models in the inspector

    private RotateKart currentRotatingKart; // Reference to the rotating kart

    private void Start()
    {
        // Assign click events with sound
        kart1Button.onClick.AddListener(() => { PlayButtonSound(); SelectKart(0); });
        kart2Button.onClick.AddListener(() => { PlayButtonSound(); SelectKart(1); });
        kart3Button.onClick.AddListener(() => { PlayButtonSound(); SelectKart(2); });
        backButton.onClick.AddListener(() => { PlayButtonSound(); ViewManager.ShowLast(); });

        // Assign hover events
        AddHoverEvents(kart1Button, 0);
        AddHoverEvents(kart2Button, 1);
        AddHoverEvents(kart3Button, 2);
    }

    private void SelectKart(int kartIndex)
    {
        PlayerPrefs.SetInt("SelectedKart", kartIndex); // Save selection
        PlayerPrefs.Save();
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayGameBGM();
        }

        SceneManager.LoadScene("GameScene");
    }

    private void AddHoverEvents(Button button, int kartIndex)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerEnter = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
        pointerEnter.callback.AddListener((data) => { PlayButtonSound(); ShowKartPreview(kartIndex); });

        EventTrigger.Entry pointerExit = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
        pointerExit.callback.AddListener((data) => HideAllKartPreviews());

        trigger.triggers.Add(pointerEnter);
        trigger.triggers.Add(pointerExit);
    }

    private void ShowKartPreview(int kartIndex)
    {
        HideAllKartPreviews();
        if (kartPreviews[kartIndex] != null)
        {
            kartPreviews[kartIndex].SetActive(true);

            // Start rotating the kart
            currentRotatingKart = kartPreviews[kartIndex].GetComponent<RotateKart>();
            if (currentRotatingKart != null)
            {
                currentRotatingKart.enabled = true;
            }
        }
    }

    private void HideAllKartPreviews()
    {
        foreach (GameObject kart in kartPreviews)
        {
            if (kart != null)
            {
                kart.SetActive(false);

                // Stop rotating the kart
                RotateKart rotateKart = kart.GetComponent<RotateKart>();
                if (rotateKart != null)
                {
                    rotateKart.enabled = false;
                }
            }
        }
    }

    private void PlayButtonSound()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonSFX();
        }
    }
}
