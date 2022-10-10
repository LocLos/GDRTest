using System;
using UnityEngine;

[RequireComponent(typeof(TriggerObserver))]
public class Coin : MonoBehaviour
{
    public Action<int> OnCoinChange;
    public Action OnTakeAllCoins;
    public int Value { get; private set; }

    [SerializeField]
    private TriggerObserver _triggerObserver;

    private int _coinCountOnLvl;

    public void Construct(int coinCountOnLvl) =>
     _coinCountOnLvl = coinCountOnLvl;

    private void Start() =>
        _triggerObserver.TriggerEnter += ChangeMoney;

    private void ChangeMoney(Collider2D obj)
    {
        if (obj.CompareTag("Coin"))
        {
            Value++;
            OnCoinChange?.Invoke(Value);

            CheckWin();
            Destroy(obj.gameObject);
        }
    }

    private void CheckWin()
    {
        if (Value >= _coinCountOnLvl)
            OnTakeAllCoins?.Invoke();
    }
}