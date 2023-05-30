using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;
    private float _minHealth = 0f;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        FindObjectOfType<HealthBar>().UpdateHealthBar();
    }

    public void Damage(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth < _minHealth)
            _currentHealth = _minHealth;

        FindObjectOfType<HealthBar>().UpdateHealthBar();
    }


    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }
}