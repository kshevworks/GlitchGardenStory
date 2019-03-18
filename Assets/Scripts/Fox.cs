using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Attacker _attacker;
    private Animator _animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _attacker = GetComponent<Attacker>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Defender defender = other.GetComponent<Defender>();
        Gravestone gravestone = other.GetComponent<Gravestone>();

        if (gravestone)
        {
            _animator.SetTrigger("JumpTrigger");
        }      
        else if (defender)
        {
            _attacker.Attack(defender.gameObject);
        }
    }
}
