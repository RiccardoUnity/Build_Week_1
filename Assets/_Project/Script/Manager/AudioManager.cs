using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music Clips")]
    public AudioClip backgroundMusic;

    [Header("SFX Clips")]
    public AudioClip hitSFX;
    public AudioClip healPickupSFX;
    public AudioClip equipPickupSFX;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayHitSFX()
    {
        PlaySFX(hitSFX);
    }

    public void PlayHealPickupSFX()
    {
        PlaySFX(healPickupSFX);
    }

    public void PlayEquipPickupSFX()
    {
        PlaySFX(equipPickupSFX);
    }

    private void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}