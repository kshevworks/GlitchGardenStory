using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private GameObject deathVfx;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVfx();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVfx()
    {
        if (!deathVfx) return;
        GameObject deathVfxObject = Instantiate(deathVfx, transform.position, Quaternion.identity);
        Destroy(deathVfxObject, 1f);
    }
}
