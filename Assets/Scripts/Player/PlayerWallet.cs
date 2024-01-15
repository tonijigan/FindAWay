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

    private void Awake() => InitSaveCoin();

    public void AddCoin(Coin coin)
    {
        _countCoin.Add(coin);
        AddedCoin?.Invoke(_countCoin.Count);
    }

    private void InitSaveCoin()
    {
        for (int i = 0; i < ProgressInfo.PlayerInfo.Coins; i++)
            _countCoin.Add(_coin);
    }
}