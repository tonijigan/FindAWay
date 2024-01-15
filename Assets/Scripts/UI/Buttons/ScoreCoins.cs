using UnityEngine;
using TMPro;

public class ScoreCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _countCoin;
    [SerializeField] private PlayerWallet _playerWallet;

    private void OnEnable()
    {
        _playerWallet.AddedCoin += AddCoin;
        ProgressInfo.Rewarded += Rewarded;
    }

    private void OnDisable()
    {
        _playerWallet.AddedCoin -= AddCoin;
        ProgressInfo.Rewarded -= Rewarded;
    }

    private void Awake() => _countCoin.text = ProgressInfo.PlayerInfo.Coins.ToString();

    private void AddCoin(int coin) => _countCoin.text = coin.ToString();

    private void Rewarded() => _countCoin.text = ProgressInfo.PlayerInfo.Coins.ToString();
}