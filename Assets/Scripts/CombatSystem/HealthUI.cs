using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth _healthSystem = null;
    [SerializeField] private TMP_Text _actualHealthTMP = null;

    private void OnEnable()
    {
        HandleHealthChanged(_healthSystem.Health);

        _healthSystem.OnPlayerHealthChanged += HandleHealthChanged;
    }

    private void OnDisable()
    {
        _healthSystem.OnPlayerHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(int health)
    {
        _actualHealthTMP.text = health.ToString();
    }
}
