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

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float bgmVolume = 0.5f; // Default BGM volume
    [Range(0f, 1f)] public float sfxVolume = 0.5f; // Default SFX volume

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
        ApplyVolumeSettings();
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
            sfxSource.PlayOneShot(buttonSFX, sfxVolume);
        }
    }

    // Method to apply volume settings
    public void ApplyVolumeSettings()
    {
        bgmSource.volume = bgmVolume;
        sfxSource.volume = sfxVolume;
    }

    // Methods to adjust volume from UI sliders
    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        bgmSource.volume = bgmVolume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;
    }
}
