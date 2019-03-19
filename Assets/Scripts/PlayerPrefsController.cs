using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "master volume";
    private const string DIFFICULTY_KEY = "difficulty";
    
    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;

    private const int MIN_DIFFICULTY = 1;
    private const int MAX_DIFFICULTY = 5;

    private const float DEFAULT_DIFFICULTY = 2f;
    private const float DEFAULT_VOLUME = 0.75f;

    public static float DefaultDifficulty => DEFAULT_DIFFICULTY;
    public static float DefaultVolume => DEFAULT_VOLUME;

    private static bool IsVolumeSetByUser => PlayerPrefs.HasKey(MASTER_VOLUME_KEY);

    private static bool IsDifficultySetByUser => PlayerPrefs.HasKey(DIFFICULTY_KEY);
    public static float MasterVolume => IsVolumeSetByUser ? PlayerPrefs.GetFloat(MASTER_VOLUME_KEY):DEFAULT_VOLUME;

    public static float DifficultyLevel => IsDifficultySetByUser? PlayerPrefs.GetFloat(DIFFICULTY_KEY) : DEFAULT_DIFFICULTY;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range.");
        }
    }

    public static void SetDifficultyLevel(float level)
    {
        if (level >= MIN_DIFFICULTY && level <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, level);
        }
        else
        {
            Debug.LogError("Difficulty is out of range.");
        }
    }

}
