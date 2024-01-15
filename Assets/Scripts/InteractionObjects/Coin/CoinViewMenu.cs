using System;
using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class CoinViewMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable() => ProgressInfo.ReceivedData += GetDate;

    private void OnDisable() => ProgressInfo.ReceivedData -= GetDate;
    
    private void Awake() => PlayerAccount.GetCloudSaveData(ProgressInfo.GetPlayerInfo);
    
    private void GetDate() => _text.text = ProgressInfo.PlayerInfo.Coins.ToString();
}