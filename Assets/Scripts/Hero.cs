using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private BackgroudRenderer _backgroudRenderer;
    [SerializeField] private SliderRenderer _sliderRenderer;

    private Animator _animator;
    private bool _isDie = false;
    private float _maxHealth;

    public void SetHealth(float number)
    {
        _health += number;

        if (_health > _maxHealth)
            _health = _maxHealth;

        _sliderRenderer.DrawHealth(_health);
    }

    private void Start()
    {
        _maxHealth = _health;
        _animator = GetComponent<Animator>();
        _sliderRenderer.SetBaseValues(_maxHealth);
    }

    private void Update()
    {
        if (_isDie)
            return;

        if (_health <= 0)
        {
            _animator.SetTrigger(AnimatorHeroController.Params.Die);
            _backgroudRenderer.enabled = false;
            _isDie = true;
        }
    }
}
