using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TurretTooltipUI : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] private TurretShop _turretShop = null;
    [SerializeField] private GameObject _tooltipDisplay = null;
    [SerializeField] private Image _turretImage = null;
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private TMP_Text _costText = null;
    [SerializeField] private TMP_Text _fireRateText = null;
    [SerializeField] private TMP_Text _rangeText = null;

    private Camera _mainCamera;
    private TurretHolder _turretHolder;

    private void OnEnable() => Turret.OnTurretSelected += TurretSelectedHandler;
    private void Start() => _mainCamera = Camera.main;
    private void OnDisable() => Turret.OnTurretSelected -= TurretSelectedHandler;

    private void TurretSelectedHandler(TurretHolder towerHolder)
    {
        _tooltipDisplay.transform.position = _mainCamera.WorldToScreenPoint(towerHolder.Turret.transform.position);

        _turretImage.sprite = towerHolder.Turret.TowerData.Icon;
        _nameText.text = towerHolder.Turret.TowerData.Name;
        _costText.text = $"${towerHolder.Turret.TowerData.Cost}";
        _fireRateText.text = $"Fire rate: {towerHolder.Turret.TowerData.FireRate}";
        _rangeText.text = $"Range: {towerHolder.Turret.TowerData.Range}";

        _turretHolder = towerHolder;

        _tooltipDisplay.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _tooltipDisplay.SetActive(false);
    }

    public void Sell()
    {
        _turretShop.SellTurret(_turretHolder.Turret.TowerData);

        _turretHolder.RemoveTower();

        _tooltipDisplay.SetActive(false);
    }
}
