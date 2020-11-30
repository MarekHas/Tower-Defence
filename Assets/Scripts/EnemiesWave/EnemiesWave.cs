using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemiesWave
{
    [SerializeField] private EnemyUnit[] _enemyUnits = new EnemyUnit[0];
    [SerializeField] private float _spawningTime;

    public EnemyUnit[] EnemyUnits => _enemyUnits;
    public float SpawningTime => _spawningTime;
}