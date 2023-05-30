using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private float _healthChangeDelay = 0.3f;

    private void Start()
    {
        _health.OnHealthChanged += UpdateHealthBar;
        UpdateHealthBar(_health.GetCurrentHealth(), _health.GetMaxHealth());
    }

    private void OnDestroy()
    {
        _health.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (_slider != null)
        {
            float targetValue = currentHealth / maxHealth;
            float currentValue = _slider.value;
            float newValue = Mathf.MoveTowards(currentValue, targetValue, Time.deltaTime * _healthChangeDelay);
            _slider.value = newValue;
        }
    }
}