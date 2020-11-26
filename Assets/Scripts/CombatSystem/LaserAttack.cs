using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private TurretData _turretData = null;
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private LineRenderer _lineRenderer = null;

    private float _timer;

    private TargetFinder _targetFinder;

    private void Start() => _targetFinder = GetComponent<TargetFinder>();

    private void Update()
    {
        EnemyUnit target = _targetFinder.EnemyTarget;

        if (target != null)
        {
            _lineRenderer.positionCount = 2;

            _lineRenderer.SetPositions(new Vector3[]
            {
                    _spawnPoint.position,
                    target.transform.position
            });
        }
        else
        {
            _lineRenderer.positionCount = 0;
        }

        _timer -= Time.deltaTime;

        if (_timer > 0f) { return; }

        _timer = _fireRate;

        if (target != null)
        {
            target.TakeDamage(Mathf.CeilToInt(_turretData.FireRate * _fireRate));
        }
    }
}
