using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private float timeToWait = 4f;

    [Header("Music Settings")] 
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip optionsMusic;
    [SerializeField] private AudioClip[] levelMusic;
    
    
    private int _currentLevelMusicIndex;
    private int _currentSceneIndex;
    
    private MusicPlayer _musicPlayer;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _musicPlayer = FindObjectOfType<MusicPlayer>();
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (_currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreenWithDelay());
        }
    }

    private IEnumerator LoadStartScreenWithDelay()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadMainMenu();
    }

    public void LoadNextScene()
    {
        if (_musicPlayer && levelMusic.Length>0)
        {
            int randomMusicIndex = Random.Range(0, levelMusic.Length); 
            _musicPlayer.SetMusic(levelMusic[randomMusicIndex]);
            _currentLevelMusicIndex = randomMusicIndex;
        }
        SceneManager.LoadScene(_currentSceneIndex  + 1);
    }
    
    public void RestartScene()
    {
        Time.timeScale = 1;
        if (_musicPlayer && levelMusic.Length>0)
        {
            _musicPlayer.SetMusic(levelMusic[_currentLevelMusicIndex]);
        }

        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadOptionsScreen()
    {
        if (_musicPlayer && optionsMusic)
        {
            _musicPlayer.SetMusic(optionsMusic);
        }
        SceneManager.LoadScene("OptionsScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        if (_musicPlayer && mainMenuMusic)
        {
            _musicPlayer.SetMusic(mainMenuMusic);
        }

        SceneManager.LoadScene("StartScreen");
    }
}
