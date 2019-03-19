using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDisplay : MonoBehaviour
{
    [SerializeField] private int lives = 20;
    [SerializeField] private int damage = 1;

    private int _countedLives;
    
    private Text _livesText;
    private LevelController _levelController;
    // Start is called before the first frame update
    private void Start()
    {
        _livesText = GetComponent<Text>();
        _levelController = FindObjectOfType<LevelController>();
        _countedLives = lives * 2 / (int) PlayerPrefsController.DifficultyLevel;
        if (_countedLives <= 0) _countedLives = 1;
        UpdateDisplay();
    }
    
    private void UpdateDisplay()
    {
        _livesText.text = _countedLives.ToString();
    }

    public void TakeLife()
    {
        _countedLives -= damage;
        UpdateDisplay();

        if (_countedLives <= 0)
        {
            _levelController.HandleLoseCondition();
        }
    }
    
    
}
