using System.Collections.Generic;
using UnityEngine;

public class GameBootstraper : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerPrefab;
    [SerializeField]
    private PlayerInput _playerInput;

    [SerializeField]
    private UI _ui;

    private PlayerMovement _player;
    private int _coinsCountOnLvl;

    private void Start()
    {
        CheckConisOnLvl();
        CreatePlayer();

        Coin playerCoin = _player.GetComponent<Coin>();
        TakeCoinCountOnLvl(playerCoin);

        _ui.Construct(
            _player.GetComponent<Health>(),
            playerCoin,
            _player.GetComponent<Death>());//  не нраица..
    }

    private void TakeCoinCountOnLvl(Coin playerCoin)
    {
        playerCoin.Construct(_coinsCountOnLvl);
    }

    private void CheckConisOnLvl()
    {
        List<GameObject> coins = new List<GameObject>();
        coins.AddRange(GameObject.FindGameObjectsWithTag("Coin"));//лучше конечно былоб их создавать а не искать
        _coinsCountOnLvl = coins.Count;
        coins.Clear();
    }

   
    private void CreatePlayer()
    {
        _player = Instantiate(_playerPrefab);
        _player.Construct(_playerInput);
    }
}
