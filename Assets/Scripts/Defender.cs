using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] private int starCost = 100;

    private StarDisplay _starDisplay;
    
    private void Start()
    {
        _starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        _starDisplay.AddStars(amount);
    }

}
