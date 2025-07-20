using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    public GameSound alarmSound;

    private int asteroidCount = 0;
    private AudioSource alarmSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void AddAsteroid()
    {
        if (alarmSource == null)
        {
            alarmSource = SoundManagerScript.instance.PlaySoundClip(alarmSound, true, transform);
        }
        asteroidCount++;
    }

    public void RemoveAsteroid()
    {
        asteroidCount--;
        if (asteroidCount == 0)
        {
            Destroy(alarmSource.gameObject);
            alarmSource = null;
        }
    }
}