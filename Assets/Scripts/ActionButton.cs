using UnityEngine;

public class ActionButton : MonoBehaviour
{
    [SerializeField] private float _number;
    [SerializeField] private Hero _hero;

    public void OnButtonClick() => _hero.SetHealth(_number);
}
