using InteractionObjects.Coin;
using Player;
using UI;
using UnityEngine;

namespace Save
{
    public class DistributeSavedData : MonoBehaviour
    {
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private CoinViewMenu _coinViewMenu;
        [SerializeField] private ScoreCoins _scoreCoins;
        [SerializeField] private PlayerSave _playerSave;

        private void Awake() => _playerSave.Load();

        private void OnEnable() => _playerSave.Loaded += InitData;

        private void OnDisable() => _playerSave.Loaded -= InitData;
        
        private void InitData()
        {
            Debug.Log($"Good {_playerSave.Coins}, {_playerSave.ScenesAccess}");

            if (_playerWallet != null)
                _playerWallet.InitSaveCoin(_playerSave.Coins);


            if (_coinViewMenu != null)
                _coinViewMenu.Init(_playerSave.Coins);


            if (_scoreCoins != null)
                _scoreCoins.Init(_playerSave.Coins);
        }
    }
}