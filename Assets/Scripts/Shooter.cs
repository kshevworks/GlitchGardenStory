using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject gun;

    private AttackerSpawner _myLaneSpawner;
    private Animator _animator;
    private GameObject _projectileParent;

    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    public void Fire()
    {
        GameObject currentProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        currentProjectile.transform.parent = _projectileParent.transform;
    }

    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        _projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
                if (!_projectileParent)
                {
                    _projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
                }
    }

    private void Update()
    {
        if (IsAttackerInLane)
        {
            _animator.SetBool("IsAttacking",true);
        }
        else
        {
            _animator.SetBool("IsAttacking",false);
        }
    }

    private bool IsAttackerInLane => _myLaneSpawner.transform.childCount > 0;


    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                _myLaneSpawner = spawner;
            }
        }
    }
}