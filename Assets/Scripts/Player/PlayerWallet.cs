using System;
using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private List<Coin> _countCoin = new List<Coin>();

    public event UnityAction<int> AddedCoin;

    private Coin _coin;

    public int CountCoins => _countCoin.Count;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.GetCloudSaveData(ProgressCoins.GetPlayerInfo);
#endif
        InitSaveCoin();
    }

    public void AddCoin(Coin coin)
    {
        _countCoin.Add(coin);
        AddedCoin?.Invoke(_countCoin.Count);
    }

    private void InitSaveCoin()
    {
        for (int i = 0; i < ProgressCoins.PlayerInfo.Coins; i++)
            _countCoin.Add(_coin);
    }
}