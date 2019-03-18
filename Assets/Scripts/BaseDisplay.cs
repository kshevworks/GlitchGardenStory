using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDisplay : MonoBehaviour
{
    [SerializeField] private int lives = 20;
    [SerializeField] private int damage = 1;

    private Text _livesText;

    private LevelLoader _levelLoader;
    // Start is called before the first frame update
    private void Start()
    {
        _livesText = GetComponent<Text>();
        _levelLoader = FindObjectOfType<LevelLoader>();
        UpdateDisplay();
    }
    
    private void UpdateDisplay()
    {
        _livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            _levelLoader.LoadLoseScreen();
        }
    }
    
    
}
