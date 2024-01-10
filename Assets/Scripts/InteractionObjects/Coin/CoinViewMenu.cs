using System;
using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class CoinViewMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable() => ProgressCoins.ReceivedData += GetDate;

    private void OnDisable() => ProgressCoins.ReceivedData -= GetDate;
    
    private void Awake() => PlayerAccount.GetCloudSaveData(ProgressCoins.GetPlayerInfo);
    
    private void GetDate() => _text.text = ProgressCoins.PlayerInfo.Coins.ToString();
}