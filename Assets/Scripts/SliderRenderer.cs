using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderRenderer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Slider _slider;

    private Coroutine _setValue;
    private readonly float _percent = 100;

    public void SetBaseValues(float maxValue)
    {
        _slider.maxValue = maxValue / _percent;
        _slider.value = _slider.maxValue;
    }

    public void DrawHealth(float health)
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
