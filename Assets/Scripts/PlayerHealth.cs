using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private Slider _healthSlider;

    private void Start()
    {
        UpdateHealthBar();
    }

    public void Heal()
    {
        _health += 10f;

        if (_health > 100f)        
            _health = 100f;        

        UpdateHealthBar();
    }

    public void Damage()
    {
        _health -= 10f;

        if (_health <= 0f)        
            _health = 0f;        

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (_healthSlider != null)
        {
            float targetValue = _health / 100f;
            float currentValue = _healthSlider.value;
            float newValue = Mathf.MoveTowards(currentValue, targetValue, Time.deltaTime * 2f);
            _healthSlider.value = newValue;
        }
    }
}