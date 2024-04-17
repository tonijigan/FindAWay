using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class CoinViewMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _data;

    private void Awake() => PlayerAccount.GetCloudSaveData(ProgressInfo.GetPlayerInfo);

    private void OnEnable() => ProgressInfo.ReceivedData += OnAssignCoins;

    private void OnDisable() => ProgressInfo.ReceivedData -= OnAssignCoins;

    private void OnAssignCoins() => _data.text = ProgressInfo.PlayerInfo.Coins.ToString();
}