using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHolder : MonoBehaviour
{
    public Turret Turret { get; private set; }

    public void SetTower(TurretData turretData)
    {
        Turret = Instantiate(turretData.TowerPrefab, transform);

        Turret.Initialise(this);
    }

    public void RemoveTower()
    {
        Destroy(Turret.gameObject);

        Turret = null;
    }
}
