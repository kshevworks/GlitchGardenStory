using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in seconds")]
    [SerializeField] private float levelTime = 10f;

    private bool _triggeredLevelFinished = false;
    
    private Slider _slider;
    private LevelController _levelController;
    
    private void Start()
    {
        _levelController = FindObjectOfType<LevelController>();
        _slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(_triggeredLevelFinished) return;
        _slider.value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = Time.timeSinceLevelLoad >= levelTime;
        if (timerFinished)
        {
            _levelController.LevelTimerFinished();
            _triggeredLevelFinished = true;
        }
    }
}
