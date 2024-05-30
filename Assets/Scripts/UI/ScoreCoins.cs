using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreCoins : AbstractDataInit
    {
        [SerializeField] private TMP_Text _countCoin;
        [SerializeField] private PlayerWallet _playerWallet;

        private void OnEnable() => _playerWallet.AddedCoin += OnAddCoin;

        private void OnDisable() => _playerWallet.AddedCoin -= OnAddCoin;

        public override void Init(int coins) => _countCoin.text = coins.ToString();

        private void OnAddCoin(int coin) => _countCoin.text = coin.ToString();
    }
}