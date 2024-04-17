using UnityEngine;
using TMPro;

public class ScoreCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _countCoin;
    [SerializeField] private PlayerWallet _playerWallet;

    private void Awake() => _countCoin.text = ProgressInfo.PlayerInfo.Coins.ToString();

    private void OnEnable()
    {
        _playerWallet.AddedCoin += OnAddCoin;
        ProgressInfo.Rewarded += OnRewarded;
    }

    private void OnDisable()
    {
        _playerWallet.AddedCoin -= OnAddCoin;
        ProgressInfo.Rewarded -= OnRewarded;
    }

    private void OnAddCoin(int coin) => _countCoin.text = coin.ToString();

    private void OnRewarded() => _countCoin.text = ProgressInfo.PlayerInfo.Coins.ToString();
}