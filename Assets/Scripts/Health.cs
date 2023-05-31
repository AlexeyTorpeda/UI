using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxHealth = 100f;
    private float _minHealth = 0f;

    private float _currentHealth;

    public delegate void OnHealthChanged(float currentHealth, float maxHealth);
    public event OnHealthChanged HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Damage(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth < _minHealth)
            _currentHealth = _minHealth;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}