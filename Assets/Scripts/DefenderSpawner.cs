using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender _defender;
    private StarDisplay _starDisplay;

    private GameObject _defenderParent;

    private const string DEFENDER_PARENT_NAME = "Defenders";
    
    public Defender Defender {
        set => _defender = value;
    }

    private void Start()
    {
        _starDisplay = FindObjectOfType<StarDisplay>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        _defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!_defenderParent)
        {
            _defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        int defenderCost = _defender.StarCost;
        if (_starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            _starDisplay.DecreaseStars(defenderCost);
        }
    }

    private void OnMouseDown()
    {
        if (_defender)
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }
        
    }


    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        
        return new Vector2(newX,newY);
    }
    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(_defender,roundedPos, Quaternion.identity);
        newDefender.transform.parent = _defenderParent.transform;
    }
}
