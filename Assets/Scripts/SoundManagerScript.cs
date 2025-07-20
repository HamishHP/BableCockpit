using Unity.VisualScripting;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript instance;
    public AudioClip musicClip;

    [Range(0f, 1f)]
    public float musicVolume = 1;

    private AudioSource musicSource;

    [SerializeField] private AudioSource soundObject;

    private float musicSliderVal, sfxSliderVal;

    [Range(0f, 1f)]
    public float initialSliderVolume;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            musicSliderVal = initialSliderVolume;
            sfxSliderVal = initialSliderVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (musicClip != null)
        {
            musicSource = GetComponent<AudioSource>();
            musicSource.clip = musicClip;
            musicSource.volume = musicVolume;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public AudioSource PlaySoundClip(GameSound soundData, bool isLooping = false, Transform soundPosition = null)
    {
        if (soundData.clip != null)
        {
            AudioSource audioSource;

            if (soundPosition == null)
            {
                audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);
            }
            else
            {
                audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);
                audioSource.spatialBlend = 1;
            }

            audioSource.clip = soundData.clip;

            audioSource.volume = soundData.volume;

            audioSource.pitch = 1 + Random.Range(soundData.pitchMin, soundData.pitchMax);

            audioSource.Play();

            float clipLength = audioSource.clip.length / Mathf.Abs(audioSource.pitch);

            if (!isLooping)
            {
                Destroy(audioSource.gameObject, clipLength);
                return null;
            }
            else
            {
                audioSource.loop = true;
                return audioSource;
            }
        }
        else
        {
            Debug.LogWarning("Lol you forgor to put a clip in this one");
            return null;
        }
    }

    public void SetMusicSlider(float sliderValue)
    {
        musicSliderVal = sliderValue;
    }

    public void SetSFXSlider(float sliderValue)
    {
        sfxSliderVal = sliderValue;
    }

    public float GetMusicSliderVal()
    {
        return musicSliderVal;
    }

    public float GetSFXSliderVal()
    {
        return sfxSliderVal;
    }
}