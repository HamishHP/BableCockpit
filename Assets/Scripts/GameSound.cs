using UnityEngine;

[CreateAssetMenu(fileName = "GameSound", menuName = "Audio/GameSound")]
public class GameSound : ScriptableObject
{
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1;

    [Range(-1f, 1f)]
    public float pitchMin = 0;

    [Range(-1f, 1f)]
    public float pitchMax = 0;
}