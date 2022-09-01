using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]

public class Hero : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth;
    private Animator _animator;
    public Action<float> HealthChanged;

    public float GetHealth => _health;

    public void TakeHeal(float number)
    {
        _health += number;

        if (_health > _maxHealth)
            _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(float number)
    {
        _health -= number;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            _animator.SetTrigger(AnimatorHeroController.Params.Die);
    }

    private void Start()
    {
        _maxHealth = _health;
        _animator = GetComponent<Animator>();
    }
}
