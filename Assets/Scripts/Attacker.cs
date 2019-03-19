using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float attackerDamage = 20f;
    [Range(0f,5f)] private float _currentSpeed = 1f;
    

    private GameObject _currentTarget;
    private Animator _animator;
    private LevelController _levelController;

    private float _countedMovementSpeed;


    private void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        _levelController.AttackerSpawned();
    }

    private void OnDestroy()
    {
        if (_levelController) _levelController.AttackerKilled();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _countedMovementSpeed);
        UpdateAnimationState();
    }

    public void SetMovementSpeed(float speed) => _countedMovementSpeed = speed * PlayerPrefsController.DifficultyLevel / 2;

    public void Attack(GameObject target)
    { 
        _animator.SetBool("IsAttacking", true);
        _currentTarget = target;
    }

    public void StrikeCurrentTarget()
    {
        if(!_currentTarget) {return;}

        Health health = _currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(attackerDamage);
        }
    }

    private void UpdateAnimationState()
    {
        if (!_currentTarget)
        {
            _animator.SetBool("IsAttacking",false);
        }
    }
}
