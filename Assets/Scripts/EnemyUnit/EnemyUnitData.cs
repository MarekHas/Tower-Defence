using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyUnitData", menuName = "Enemy/EnemyUnitData")]
public class EnemyUnitData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _health = 10;
    [SerializeField] private int _moneyForKill = 10;
    [SerializeField] private float _speed = 5f;

    public int Damage => _damage;
    public int Health => _health;
    public int MoneyForKill => _moneyForKill;
    public float Speed => _speed;
}