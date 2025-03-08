using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton instance

    [Header("Audio Sources")]
    public AudioSource bgmSource; // Background Music Source
    public AudioSource sfxSource; // Sound Effects Source

    [Header("Audio Clips")]
    public AudioClip menuBGM; // BGM for menu scene
    public AudioClip gameBGM; // BGM for game scene
    public AudioClip buttonSFX; // Sound effect for button hover/click

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps audio across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    private void Start()
    {
        PlayMenuBGM(); // Start with menu music
    }

    public void PlayMenuBGM()
    {
        if (bgmSource.clip != menuBGM)
        {
            bgmSource.clip = menuBGM;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlayGameBGM()
    {
        if (bgmSource.clip != gameBGM)
        {
            bgmSource.clip = gameBGM;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlayButtonSFX()
    {
        if (sfxSource != null && buttonSFX != null)
        {
            sfxSource.PlayOneShot(buttonSFX);
        }
    }
}
