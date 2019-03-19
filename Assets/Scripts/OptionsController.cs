using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [Header("Volume")] 
    [SerializeField] private Slider volumeSlider;
    
    [Header("Difficulty")] 
    [SerializeField] private Slider difficultySlider;

    private MusicPlayer _musicPlayer;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.MasterVolume;
        difficultySlider.value = PlayerPrefsController.DifficultyLevel;
        _musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_musicPlayer) _musicPlayer.SetVolume(volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficultyLevel(difficultySlider.value);
    }

    public void SetDefaults()
    {
        volumeSlider.value = PlayerPrefsController.DefaultVolume;
        difficultySlider.value = PlayerPrefsController.DefaultDifficulty;
    }
}