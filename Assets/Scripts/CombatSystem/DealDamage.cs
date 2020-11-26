using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage: MonoBehaviour
{
    [SerializeField] private int _damge = 10;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent<EnemyUnit>(out var enemy))
        {
            return;
        }

        enemy.TakeDamage(_damge);
    }
}
