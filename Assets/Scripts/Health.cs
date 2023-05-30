using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float MaxHealth = 100f;
    private const float MinHealth = 0f;
    private const float HealthChangeDelay = 0.3f;

    private float _currentHealth = MaxHealth;

    public delegate void HealthChanged(float currentHealth, float maxHealth);
    public event HealthChanged OnHealthChanged;

    private void Start()
    {
        UpdateHealthBar();
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
        if (amount != 0)
        {
            float targetHealth = Mathf.Clamp(_currentHealth + amount, MinHealth, MaxHealth);
            float startTime = Time.time;
            float endTime = startTime + HealthChangeDelay;

            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / HealthChangeDelay;
                _currentHealth = Mathf.Lerp(_currentHealth, targetHealth, progress);
                yield return null;
            }

            _currentHealth = targetHealth;
            UpdateHealthBar();
            OnHealthChanged?.Invoke(_currentHealth, MaxHealth);
        }
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    private void UpdateHealthBar()
    {
        OnHealthChanged?.Invoke(_currentHealth, MaxHealth);
    }
}