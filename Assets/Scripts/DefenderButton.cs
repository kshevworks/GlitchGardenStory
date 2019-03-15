using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [Header("Button Settings")]
    [SerializeField] private Color activeColor = Color.white;
    [SerializeField] private Color inactiveColor = new Color(0.3f,0.3f,0.3f);

    [SerializeField] private Defender defenderPrefab;
    
    private DefenderButton[] _defenderButtons;
    private DefenderSpawner _defenderSpawner;
    
    private void Start()
    {
        _defenderButtons = FindObjectsOfType<DefenderButton>();
        _defenderSpawner = FindObjectOfType<DefenderSpawner>();
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
