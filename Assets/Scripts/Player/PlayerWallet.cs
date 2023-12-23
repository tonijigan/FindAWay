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
        PlayerAccount.GetCloudSaveData(OnSuccessCallback);
#endif
        InitSaveCoin();
    }

    private void OnSuccessCallback(string data)
    {
        StaticCoins.SetCoins(Convert.ToInt32(data));
    }

    public void AddCoin(Coin coin)
    {
        _countCoin.Add(coin);
        StaticCoins.SetCoins(_countCoin.Count);
        AddedCoin?.Invoke(_countCoin.Count);
    }

    private void InitSaveCoin()
    {
        for (int i = 0; i < StaticCoins.Coins; i++)
            _countCoin.Add(_coin);
    }
}