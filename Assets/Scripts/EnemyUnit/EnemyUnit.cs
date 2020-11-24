using System;
using UnityEngine;


public class EnemyUnit : MonoBehaviour
{
    [SerializeField] private EnemyUnitData _enemyUnitData = null;

    private PathPoint _targetPoint;
    private Vector3 _direction;
    private int _health;
    private const float _minDistance = 0.1f;

    public static event Action<EnemyUnitData> OnEnemyUnitKilled;
    public EnemyUnitData EnemyUnitData => _enemyUnitData;

    private void Start() => _health = _enemyUnitData.Health;

    private void Update()
    {
        if (_targetPoint == null) { return; }

        MoveToPoint();
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Max(_health - damage, 0);

        if (_health == 0)
        {
            OnEnemyUnitKilled?.Invoke(_enemyUnitData);

            Destroy(gameObject);
        }
    }

    private void MoveToPoint()
    {
        transform.Translate(_direction * _enemyUnitData.Speed * Time.deltaTime, Space.World);

        if ((transform.position - _targetPoint.transform.position).sqrMagnitude < _minDistance * _minDistance)
        {
            SetNextPoint(_targetPoint.NextPoint);
        }
    }

    public void SetNextPoint(PathPoint nextPoint)
    {
        _targetPoint = nextPoint;

        if (_targetPoint == null) { return; }

        _direction = (_targetPoint.transform.position - transform.position).normalized;

        if (_direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_direction);
        }
    }
}