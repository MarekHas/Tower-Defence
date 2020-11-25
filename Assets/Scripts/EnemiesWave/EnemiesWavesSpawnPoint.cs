using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesWavesSpawnPoint : MonoBehaviour
{
    [SerializeField] private PathPoint _startPoint = null;
    [SerializeField] private EnemiesWave[] _waves = new EnemiesWave[0];

    private readonly Queue<EnemyUnit> _spawnsLeft = new Queue<EnemyUnit>();

    private bool _isSpawning;
    private float _nextSpawnTime;

    private EnemiesWave _currentWave;

    private const float _spawningRate = 0.5f;

    public EnemyUnit[] GetWave(int waveIndex) => _waves[waveIndex].EnemyUnits;

    private void Update()
    {
        if (!_isSpawning) { return; }

        _nextSpawnTime -= Time.deltaTime;

        if (_nextSpawnTime <= 0f)
        {
            NextEnemy();
        }
    }

    public void StartEnemyWave(int waveIndex)
    {
        if (waveIndex >= _waves.Length) { return; }

        _currentWave = _waves[waveIndex];

        foreach (var enemy in _currentWave.EnemyUnits)
        {
            _spawnsLeft.Enqueue(enemy);
        }

        NextEnemy();

        _isSpawning = true;
    }

    private void NextEnemy()
    {
        if (_spawnsLeft.Count == 0) { return; }

        EnemyUnit enemy = Instantiate(_spawnsLeft.Dequeue(), transform.position, transform.rotation);

        enemy.SetNextPoint(_startPoint);

        if (_spawnsLeft.Count == 0)
        {
            _isSpawning = false;
            return;
        }

        _nextSpawnTime = _spawningRate;
    }
}
