using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderRenderer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Slider _slider;
    [SerializeField] private Hero _hero;

    private Coroutine _setValue;
    private readonly float _percent = 100;
 
    public void Start()
    {
        _slider.maxValue = _hero.GetHealth / _percent;
        _slider.value = _slider.maxValue;
    }

    private void OnEnable()
    {
        _hero.HealthChanged += DrawHealth;
    }

    private void OnDisable()
    {
        _hero.HealthChanged -= DrawHealth;
    }

    private void DrawHealth(float health)
    {
        if (_setValue != null)
            StopCoroutine(_setValue);

        float targetValue = health / _percent;
        _setValue = StartCoroutine(Set(targetValue));
    }

    private IEnumerator Set(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);

            yield return null;
        }
    }
}
