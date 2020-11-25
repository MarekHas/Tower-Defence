using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Turret : MonoBehaviour
{
    [SerializeField] private TurretData _turretData = null;

    public static event Action<TurretHolder> OnTurretSelected;

    private TurretHolder _turretHolder;

    public TurretData TowerData => _turretData;

    public void Initialise(TurretHolder turretHolder)
    {
        _turretHolder = turretHolder;
    }

    private void OnMouseDown() => OnTurretSelected?.Invoke(_turretHolder);
}