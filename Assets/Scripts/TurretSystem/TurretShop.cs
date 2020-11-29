using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretShop : MonoBehaviour
{
    [SerializeField] private int _resources;
    [SerializeField] private Transform _buttonHolder = null;
    [SerializeField] private BuyTurretButton _buyTurretButton = null;
    [SerializeField] private TurretData[] _turrets = new TurretData[0];

    public event Action<int> OnResourcesChanged;

    public int Resources => _resources;

    private void OnEnable()
    {
        EnemyUnit.OnEnemyUnitKilled += EnemyKilledHandler;
    }

    private void Start()
    {
        foreach (var towerData in _turrets)
        {
            BuyTurretButton towerShopButtonInstance = Instantiate(_buyTurretButton, _buttonHolder);

            towerShopButtonInstance.Initialise(towerData, this);
        }
    }

    private void OnDisable()
    {
        EnemyUnit.OnEnemyUnitKilled -= EnemyKilledHandler;
    }

    private void EnemyKilledHandler(EnemyUnitData enemyUnitData)
    {
        _resources += enemyUnitData.MoneyForKill;

        OnResourcesChanged?.Invoke(_resources);
    }

    public void BuyTurret(int value)
    {
        _resources -= value;

        OnResourcesChanged?.Invoke(_resources);
    }

    public void SellTurret(TurretData turret)
    {
        _resources += turret.Cost;

        OnResourcesChanged?.Invoke(_resources);
    }
}
