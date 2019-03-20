using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f, rotateSpeed = 1f;
    [SerializeField] private float damage = 100;

    
    private void Update()
    {
        transform.Translate(Vector2.right*Time.deltaTime*moveSpeed, Space.World);
        transform.RotateAround(transform.localPosition, Vector3.forward, rotateSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        Attacker attacker = other.GetComponent<Attacker>();
        
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
