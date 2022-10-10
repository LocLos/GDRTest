using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _coinsText;
    [SerializeField]
    private TMP_Text _lifeText;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private GameObject _winPanel;

    private Health _health;
    private Coin _coin;
    private Death _death;

    public void Construct(Health health, Coin coin, Death death)
    {
        _health = health;
        _coin = coin;
        _death = death;

        FirstUpdateText();
        SubscribeOnEvent();
    }
    private void Start()
    {
        ShowRestartButton(false);
        ShowWinPanel(false);
    }
    private void FirstUpdateText()
    {
        CoinChangeHandler(_coin.Value);
        HealthChangeHandler(_health.Value);
    }

    private void SubscribeOnEvent()
    {
        _health.OnChangeHealth += HealthChangeHandler;
        _coin.OnCoinChange += CoinChangeHandler;
        _coin.OnTakeAllCoins += ShowWinPanel;
        _death.Happend += ShowRestartButton;
    }

    public void ShowRestartButton(bool isActive) =>
       _restartButton.gameObject.SetActive(isActive);

    public void ShowWinPanel(bool isActive)
    {
        _restartButton.gameObject.SetActive(isActive);
        _winPanel.SetActive(isActive);
    }
    private void CoinChangeHandler(int newCoins) =>
       _coinsText.text = "Coins: " + newCoins;

    private void HealthChangeHandler(int newHealth) =>
        _lifeText.text = "Health: " + newHealth;

    private void ShowWinPanel() =>
        ShowWinPanel(true);

    private void ShowRestartButton() =>
        ShowRestartButton(true);
}
