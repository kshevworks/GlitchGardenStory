using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 100;

    private int _countedStars;

    private Text _starDisplay;
    
    // Start is called before the first frame update
    private void Start()
    {
        _starDisplay = GetComponent<Text>();
        _countedStars = stars * 2 / (int) PlayerPrefsController.DifficultyLevel;
        UpdateDisplay();
    }

    public void AddStars(int value)
    {
        _countedStars += value;
        UpdateDisplay();
    }

    public void DecreaseStars(int value)
    {
        if (value > _countedStars) return;

        _countedStars -= value;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _starDisplay.text = _countedStars.ToString();
    }

    public bool HaveEnoughStars(int amount) => amount <= _countedStars;
    
    
}
