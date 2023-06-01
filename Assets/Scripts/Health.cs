using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _minHealth = 0f;

    private float _currentHealth;

    public event UnityAction<float, float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Damage(float amount)
    {
        ChangeHealth(-amount);
    }

    public void Heal(float amount)
    {
        ChangeHealth(amount);
    }

    private void ChangeHealth(float amount)
    {
        float targetHealth = Mathf.Clamp(_currentHealth + amount, _minHealth, _maxHealth);
        _currentHealth = targetHealth;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}