using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEditor;
using Unity.Collections;

public class EnemiesWavesManager : MonoBehaviour
{
    [ReadOnly] [SerializeField] private int _numberOfWaves = 0;
    [SerializeField] private int _nextWaveTime = 10;
    [SerializeField] private TMP_Text _nextWaveTimeText = null;
    [SerializeField] private EnemiesWavesSpawnPoint[] _enemiesWavesSpawnPoints = new EnemiesWavesSpawnPoint[0];

    private int _currentWave;
    private float _nextWaveTimeCounter;

    private readonly Dictionary<EnemyUnitData, int> _enemiesLeftToKill = new Dictionary<EnemyUnitData, int>();

    public static event Action OnPlayersWins;

    private void OnEnable()
    {
        PlayerBase.OnEnemyUnitGetToBase += EnemyKilledHandler;
        EnemyUnit.OnEnemyUnitKilled += EnemyKilledHandler;
    }

    private void Start()
    {
        GetWavesNumber();
        GetNextWave();
        ResetTimer();
    }

    private void OnDisable()
    {
        PlayerBase.OnEnemyUnitGetToBase -= EnemyKilledHandler;
        EnemyUnit.OnEnemyUnitKilled -= EnemyKilledHandler;
    }

    private void Update()
    {
        if (_nextWaveTimeCounter == 0f) { return; }

        _nextWaveTimeCounter -= Time.deltaTime;

        if (_nextWaveTimeCounter <= 0f)
        {
            _nextWaveTimeCounter = 0f;
            _nextWaveTimeText.enabled = false;

            StartNextWave();
        }

        _nextWaveTimeText.text = Mathf.Ceil(_nextWaveTimeCounter).ToString();
    }

    private void GetWavesNumber()
    {
        foreach (var item in _enemiesWavesSpawnPoints)
        {
            _numberOfWaves += item.Waves.Length;
        }
    }

    private void StartNextWave()
    {
        foreach (var spawner in _enemiesWavesSpawnPoints)
        {
            spawner.StartEnemyWave(_currentWave);
        }
    }

    private void EnemyKilledHandler(EnemyUnitData enemyUnitData)
    {
        if (_enemiesLeftToKill.ContainsKey(enemyUnitData))
        {
            _enemiesLeftToKill[enemyUnitData]--;

            if (_enemiesLeftToKill[enemyUnitData] == 0)
            {
                _enemiesLeftToKill.Remove(enemyUnitData);
            }
        }

        if (_enemiesLeftToKill.Count == 0)
        {
            _currentWave++;

            if (_currentWave == _numberOfWaves)
            {
                OnPlayersWins?.Invoke();
                return;
            }

            GetNextWave();
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        _nextWaveTimeCounter = _nextWaveTime;
        _nextWaveTimeText.enabled = true;
    }

    private void GetNextWave()
    {
        foreach (var spawner in _enemiesWavesSpawnPoints)
        {
            foreach (var newEnemy in spawner.GetWave(_currentWave))
            {
                if (_enemiesLeftToKill.ContainsKey(newEnemy.EnemyUnitData))
                {
                    _enemiesLeftToKill[newEnemy.EnemyUnitData]++;
                }
                else
                {
                    _enemiesLeftToKill.Add(newEnemy.EnemyUnitData, 1);
                }
            }
        }
    }
}
