using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBase : MonoBehaviour
{
    public static event Action<EnemyUnitData> OnEnemyUnitGetToBase;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent<EnemyUnit>(out var enemyUnit))
        {
            return;
        }

        OnEnemyUnitGetToBase?.Invoke(enemyUnit.EnemyUnitData);

        Destroy(enemyUnit.gameObject);
    }
}
