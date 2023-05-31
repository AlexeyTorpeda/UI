using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private float _healthChangeDelay = 0.3f;

    private void OnEnable()
    {
        if (_health != null)
            _health.HealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        if (_health != null)
            _health.HealthChanged -= UpdateHealthBar;
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