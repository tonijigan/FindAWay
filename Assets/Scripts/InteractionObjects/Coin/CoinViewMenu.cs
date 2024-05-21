using Agava.YandexGames;
using SDK;
using TMPro;
using UnityEngine;

namespace InteractionObjects.Coin
{
    public class CoinViewMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _data;

        public void Init(int coins)
        {
            Debug.Log($"CoinViewMenu {coins}");
            _data.text = coins.ToString();
        }

        //private void Awake() => PlayerAccount.GetCloudSaveData(ProgressInfo.GetPlayerInfo);

        // private void OnEnable() => ProgressInfo.ReceivedData += OnAssignCoins;

        // private void OnDisable() => ProgressInfo.ReceivedData -= OnAssignCoins;

        // private void OnAssignCoins() => _data.text = ProgressInfo.PlayerInfo.Coins.ToString();
    }
}