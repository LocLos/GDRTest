using System;
using UnityEngine;

[RequireComponent(typeof(TriggerObserver))]
public class Health : MonoBehaviour
{
    public event Action<int> OnChangeHealth;
    public int Value { get { return _value; } }

    [SerializeField]
    private int _value;

    [SerializeField]
    private TriggerObserver _triggerObserver;

    private const string Dangerous = "Dangerous";

    private void Start() =>
        _triggerObserver.TriggerEnter += GetDamage;

    private void GetDamage(Collider2D obj)
    {
        if (obj.CompareTag(Dangerous))
        {
            _value--;
            OnChangeHealth?.Invoke(_value);
        }
    }


}
