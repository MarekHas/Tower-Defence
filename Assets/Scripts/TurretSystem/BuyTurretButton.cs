using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BuyTurretButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private TMP_Text _costText = null;
    [SerializeField] private Image _iconImage = null;

    private Camera _mainCamera;
    private TurretData _turretData;
    private TurretShop _turretShop;
    private TurretPreview _preview;

    private void Start() => _mainCamera = Camera.main;

    public void Initialise(TurretData turretData, TurretShop turretShop)
    {
        _costText.text = $"${turretData.Cost}";
        _iconImage.sprite = turretData.Icon;

        _turretData = turretData;
        _turretShop = turretShop;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_turretShop.Resources < _turretData.Cost) { return; }

        _preview = Instantiate(_turretData.PreviewPrefab);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_preview == null) { return; }

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<TurretHolder>(out var towerHolder))
            {
                if (towerHolder.Turret == null)
                {
                    towerHolder.SetTower(_turretData);

                    _turretShop.BuyTurret(_turretData.Cost);
                }
            }
        }

        Destroy(_preview.gameObject);
    }
}
