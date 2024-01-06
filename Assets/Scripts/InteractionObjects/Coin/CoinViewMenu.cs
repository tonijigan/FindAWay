using System;
using TMPro;
using UnityEngine;
using Agava.YandexGames;

public class CoinViewMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

#if UNITY_WEBGL && !UNITY_EDITOR
    private void Start()
    {
        PlayerAccount.GetCloudSaveData(ProgressCoins.GetPlayerInfo);
        _text.text = ProgressCoins.PlayerInfo.Coins.ToString();
    }
#endif
}