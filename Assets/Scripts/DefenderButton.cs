using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [Header("Button Settings")]
    [SerializeField] private Color activeColor = Color.white;
    [SerializeField] private Color inactiveColor = new Color(0.3f,0.3f,0.3f);

    [SerializeField] private Defender defenderPrefab;
    
    private DefenderButton[] _defenderButtons;
    private DefenderSpawner _defenderSpawner;
    private Text _costText;
    
    private void Start()
    {
        _defenderButtons = FindObjectsOfType<DefenderButton>();
        _defenderSpawner = FindObjectOfType<DefenderSpawner>();
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        _costText = GetComponentInChildren<Text>();
        if (!_costText)
        {
            Debug.LogError(name + " has no cost text.");
        }
        else
        {
            _costText.text = defenderPrefab.StarCost.ToString();
        }
    }

    private void OnMouseDown()
    {
        
        foreach (var defenderButton in _defenderButtons)
        {
            SpriteRenderer defenderButtonSprite = defenderButton.GetComponent<SpriteRenderer>();
            defenderButtonSprite.color = inactiveColor;
        }

        SpriteRenderer currentDefenderButtonSprite = gameObject.GetComponent<SpriteRenderer>();
        currentDefenderButtonSprite.color = activeColor;
        _defenderSpawner.Defender = defenderPrefab;
    }
}
