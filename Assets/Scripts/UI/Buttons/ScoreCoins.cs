using UnityEngine;
using TMPro;

public class ScoreCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _countCoin;
    [SerializeField] private PlayerWallet _playerWallet;

    private void OnEnable() => _playerWallet.AddedCoin += AddCoin;

    private void OnDisable() => _playerWallet.AddedCoin -= AddCoin;

    private void Awake()
    {
        _countCoin.text = _playerWallet.CountCoins.ToString();
    }

    private void AddCoin(int coin)
    {
        _countCoin.text = coin.ToString();
    }
}