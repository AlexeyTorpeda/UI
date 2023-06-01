using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
        
    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float targetValue = currentHealth / maxHealth;
        float currentValue = _slider.value;
        float newValue = Mathf.MoveTowards(currentValue, targetValue, Time.deltaTime);
        _slider.value = newValue;
    }
}