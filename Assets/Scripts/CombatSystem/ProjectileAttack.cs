using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun: MonoBehaviour
{
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private Rigidbody _projectile = null;
    [SerializeField] private float _force = 5f;

    private float _timer;

    private TargetFinder _targetFinder;

    private void Start() => _targetFinder = GetComponent<TargetFinder>();

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer > 0f) { return; }

        _timer = _fireRate;

        EnemyUnit target = _targetFinder.EnemyTarget;

        if (target == null) { return; }

        Rigidbody projectileInstance = Instantiate(_projectile, _spawnPoint.position, _spawnPoint.rotation);

        projectileInstance.AddForce(_spawnPoint.forward * _force, ForceMode.VelocityChange);
    }
}
