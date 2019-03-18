using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private Attacker _attacker;
    private void Start()
    {
        _attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Defender defender = other.gameObject.GetComponent<Defender>();

        if (defender)
        {
            _attacker.Attack(defender.gameObject);
        }
        


    }
}
