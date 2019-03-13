using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private float timeToWait = 4f;
    
    private int _currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (_currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreenWithDelay());
        }
    }

    private IEnumerator LoadStartScreenWithDelay()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }
}
