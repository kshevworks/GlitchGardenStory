using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 100;

    private Text starDisplay;
    
    // Start is called before the first frame update
    private void Start()
    {
        starDisplay = GetComponent<Text>();
        UpdateDisplay();
    }

    public void AddStars(int value)
    {
        stars += value;
        UpdateDisplay();
    }

    public void DecreaseStars(int value)
    {
        if (value > stars) return;

        stars -= value;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starDisplay.text = stars.ToString();
    }
    
}
