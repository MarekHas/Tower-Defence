using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret Data", menuName = "Turret/Turret Data")]
public class TurretData : ScriptableObject
{
    [SerializeField] private new string _name = "New Tower Name";
    [SerializeField] private int _cost = 100;
    [SerializeField] private float _fireRate = 10f;
    [SerializeField] private float _range = 5f;
    [SerializeField] private Sprite _icon = null;
    [SerializeField] private TurretPreview _preview = null;
    [SerializeField] private Turret _model = null;

    public string Name => _name;
    public int Cost => _cost;
    public float FireRate => _fireRate;
    public float Range => _range;
    public Sprite Icon => _icon;
    public TurretPreview PreviewPrefab => _preview;
    public Turret TowerPrefab => _model;
}
