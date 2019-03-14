using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameArea : MonoBehaviour
{
    [SerializeField] private GameObject defender;

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
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
        GameObject newDefender = Instantiate(defender,roundedPos, Quaternion.identity);
    }
}
