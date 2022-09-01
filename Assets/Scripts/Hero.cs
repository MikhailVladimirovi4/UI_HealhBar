using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private SliderRenderer _sliderRenderer;

    private float _maxHealth;

    public float GetHealth => _health;

    public void AddHealth(float number) => SetHealth(number);

    public void RemoveHealth(float number) => SetHealth(number);

    private void SetHealth(float number)
    {
        _health += number;

        if (_health > _maxHealth)
            _health = _maxHealth;

        _sliderRenderer.DrawHealth(_health);
    }

    private void Start()
    {
        _maxHealth = _health;
        _sliderRenderer.SetBaseValues(_maxHealth);
    }
}
