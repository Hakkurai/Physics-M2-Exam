using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip menuBGM;
    public AudioClip gameBGM;
    public AudioClip buttonSFX;
    public AudioClip winSFX;
    public AudioClip loseSFX;
    public AudioClip coinSFX;
    public AudioClip bananaSFX;

    [Header("Car SFX")]
    public AudioClip engineSFX; 


    [Header("Volume Settings")]
    [Range(0f, 1f)] public float bgmVolume = 0.5f;
    [Range(0f, 1f)] public float sfxVolume = 0.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ApplyVolumeSettings();
        PlayMenuBGM();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayCorrectBGM();  
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
        if (bgmSource.clip != gameBGM || !bgmSource.isPlaying)
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

    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip, sfxVolume);
        }
    }

    public void PlayWinSFX()
    {
        if (sfxSource != null && winSFX != null)
        {
            sfxSource.PlayOneShot(winSFX, sfxVolume);
        }
    }

    public void PlayLoseSFX()
    {
        if (sfxSource != null && loseSFX != null)
        {
            sfxSource.PlayOneShot(loseSFX, sfxVolume);
        }
    }

    public void PlayEngineSFX(bool isMoving)
    {
        if (isMoving)
        {
            if (!sfxSource.isPlaying || sfxSource.clip != engineSFX)
            {
                sfxSource.clip = engineSFX;
                sfxSource.loop = true;
                sfxSource.Play();
            }
        }
        else
        {
            if (sfxSource.isPlaying && sfxSource.clip == engineSFX)
            {
                sfxSource.Stop();
            }
        }
    }

    public void ApplyVolumeSettings()
    {
        bgmSource.volume = bgmVolume;
        sfxSource.volume = sfxVolume;
    }

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

    public void StopBGM()
    {
        if (bgmSource.isPlaying)
        {
            bgmSource.Stop();
        }
    }

    private void PlayCorrectBGM()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "MainMenu")
        {
            PlayMenuBGM();
        }
        else if (sceneName == "GameScene")
        {
            PlayGameBGM();
        }
    }
}
