using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class CoinViewMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _data;

    private void Awake() => PlayerAccount.GetCloudSaveData(ProgressInfo.GetPlayerInfo);

    private void OnEnable() => ProgressInfo.ReceivedData += GetDate;

    private void OnDisable() => ProgressInfo.ReceivedData -= GetDate;

    private void GetDate() => _data.text = ProgressInfo.PlayerInfo.Coins.ToString();
}