using System;
using UnityEngine;

[RequireComponent (typeof( Health))]
public class Death : MonoBehaviour
{
    [SerializeField]
    private Health _health;
    public Action Happend;
    private void Start() => 
        _health.OnChangeHealth += DeathCheck;

    private void DeathCheck(int health)
    {
        if (health <= 0)
        {
            Happend?.Invoke();
            Destroy(gameObject);
        }
    }
}