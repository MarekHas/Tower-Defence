using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestTargetFinder: TargetFinder
{
    protected override void FindTarget()
    {
        int enemiesColliders = Physics.OverlapSphereNonAlloc(transform.position, _turretData.Range, _colliderBuffer, _layerMask);

        EnemyUnit closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < enemiesColliders; i++)
        {
            float distanceSquared = (_colliderBuffer[i].transform.position - transform.position).sqrMagnitude;

            if (distanceSquared < closestDistance * closestDistance)
            {
                if (_colliderBuffer[i].TryGetComponent<EnemyUnit>(out var enemy))
                {
                    closestDistance = distanceSquared;
                    closestEnemy = enemy;
                }
            }
        }

        EnemyTarget = closestEnemy;
    }
}
