using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    public event Action<int> OnPlayerHealthChanged;
    public static event Action OnPlayerDefeat;

    public int Health => _health;

    private void OnEnable() => PlayerBase.OnEnemyUnitGetToBase += EnemyReachedBaseHandler;
    private void OnDisable() => PlayerBase.OnEnemyUnitGetToBase -= EnemyReachedBaseHandler;

    private void EnemyReachedBaseHandler(EnemyUnitData enemyData)
    {
        _health = Mathf.Max(_health - enemyData.Damage);

        OnPlayerHealthChanged?.Invoke(_health);

        if (_health != 0) { return; }

        OnPlayerDefeat?.Invoke();
    }
}
