using System;
using UnityEngine;

public class TriggerObserver : MonoBehaviour
{
    public Action<Collider2D> TriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision) =>
        TriggerEnter?.Invoke(collision);
}
