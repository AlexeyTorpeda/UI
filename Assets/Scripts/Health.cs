using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float _maxHealth = 100f;
    private float _minHealth = 0f;
    private float _healthChangeDelay = 50f;

    private float _currentHealth;

    public event UnityAction<float, float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float amount)
    {
        StartCoroutine(ChangeHealth(amount));
    }

    public void Damage(float amount)
    {
        StartCoroutine(ChangeHealth(-amount));
    }

    private IEnumerator ChangeHealth(float amount)
    {
        float targetHealth = Mathf.Clamp(_currentHealth + amount, _minHealth, _maxHealth);

        while (_currentHealth != targetHealth)
        {
            float newHealth = Mathf.MoveTowards(_currentHealth, targetHealth, Time.deltaTime * _healthChangeDelay);
            HealthChanged?.Invoke(newHealth, _maxHealth);
            _currentHealth = newHealth;
            yield return null;
        }
    }
}