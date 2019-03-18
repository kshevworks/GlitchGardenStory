using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private BaseDisplay _baseDisplay;
    private void Start()
    {
        _baseDisplay = FindObjectOfType<BaseDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _baseDisplay.TakeLife();
        Destroy(other.gameObject, 2f);
    }
}
