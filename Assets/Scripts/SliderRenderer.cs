using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderRenderer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Slider _slider;

    private Coroutine _setValue;

    public void SetBaseValues(float maxValue)
    {
        _slider.maxValue = maxValue;
        _slider.value = _slider.maxValue;
    }

    public void DrawHealth(float targetValue)
    {
        if (_setValue != null)
            StopCoroutine(_setValue);

        _setValue = StartCoroutine(Set(targetValue));
    }

    private IEnumerator Set(float _targetValue)
    {
        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);

            yield return null;
        }
    }
}
