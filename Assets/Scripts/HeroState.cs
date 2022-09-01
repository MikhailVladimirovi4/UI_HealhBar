using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class HeroState : MonoBehaviour
{
    [SerializeField] private BackgroudRenderer _backgroudRenderer;
    [SerializeField] private  UnityEvent _reached;
    [SerializeField] private Hero _hero;

    private bool _isAlive = true;

    public void Update()
    {
        if (_hero.GetHealth <= 0 && _isAlive)
        {
            _reached?.Invoke();
            _isAlive = false;
        }
    }
}

