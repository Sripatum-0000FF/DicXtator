using System;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private Sound[] music, sfx;
    [SerializeField] private AudioSource musicSource, sfxSource;

    private void Awake()
    {
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

    public void PlaySFX(string name, float lowestPitch, float highestPitch)
    {
        Sound sound = Array.Find(sfx, x => x.name == name);

        if (sound == null)
        {
            Debug.LogWarning("No sound Found.");
        }
        else
        {
            sfxSource.pitch = UnityEngine.Random.Range(lowestPitch, highestPitch);
            sfxSource.PlayOneShot(sound.audioClip);
        }

    }

    public void Play3DSFX(string name, Vector3 position, float lowestPitch, float highestPitch)
    {
     
    }

    public void OnSFXVolumeChange(float number)
    {
        sfxSource.volume = number * 0.01f;
    }

    public void OnMusicVolumeChange(float number)
    {
        musicSource.volume = number * 0.01f;
    }

}
