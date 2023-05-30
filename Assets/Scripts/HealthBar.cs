using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (_slider != null && _health != null)
        {
            float targetValue = _health.GetCurrentHealth() / _health.GetMaxHealth();
            float currentValue = _slider.value;
            float newValue = Mathf.MoveTowards(currentValue, targetValue, Time.deltaTime * 0.3f);
            _slider.value = newValue;
        }
    }
}