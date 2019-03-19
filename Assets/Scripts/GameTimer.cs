using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in seconds")]
    [SerializeField] private float levelTime = 10f;

    private bool _triggeredLevelFinished = false;
    private float _countedLevelTime;
    
    private Slider _slider;
    private LevelController _levelController;
    
    private void Start()
    {
        _levelController = FindObjectOfType<LevelController>();
        _slider = GetComponent<Slider>();
        _countedLevelTime = levelTime * PlayerPrefsController.DifficultyLevel / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        if(_triggeredLevelFinished) return;
        _slider.value = Time.timeSinceLevelLoad / _countedLevelTime;

        bool timerFinished = Time.timeSinceLevelLoad >= _countedLevelTime;
        if (timerFinished)
        {
            _levelController.LevelTimerFinished();
            _triggeredLevelFinished = true;
        }
    }
}
