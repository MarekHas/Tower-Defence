using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetFinder : MonoBehaviour
{
    [SerializeField] protected TurretData _turretData = null;
    [SerializeField] private float _rate = 0.5f;
    [SerializeField] protected LayerMask _layerMask = new LayerMask();

    private float _timer;

    protected readonly Collider[] _colliderBuffer = new Collider[50];

    public EnemyUnit EnemyTarget { get; protected set; }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            _timer = _rate;

            FindTarget();
        }

        if (EnemyTarget == null) { return; }

        transform.LookAt(EnemyTarget.transform);
    }

    protected abstract void FindTarget();
}
