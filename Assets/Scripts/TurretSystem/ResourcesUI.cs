using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private TurretShop _turretShop = null;
    [SerializeField] private TMP_Text _resourcesText = null;

    private void OnEnable()
    {
        HandleMoneyChanged(_turretShop.Resources);

        _turretShop.OnResourcesChanged += HandleMoneyChanged;
    }

    private void OnDisable()
    {
        _turretShop.OnResourcesChanged -= HandleMoneyChanged;
    }

    private void HandleMoneyChanged(int resources)
    {
        _resourcesText.text = $"${resources}";
    }
}
