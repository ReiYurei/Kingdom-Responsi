using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    [SerializeField] float attackPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.OnDamage(attackPower);
        }
    }
}
