using System;
using System.Collections.Generic;
using InteractionObjects.Coin;
using SDK;
using UnityEngine;

namespace Player
{
    public class PlayerWallet : MonoBehaviour
    {
        private readonly List<Coin> _countCoin = new List<Coin>();

        public event Action<int> AddedCoin;

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
            for (var i = 0; i < ProgressInfo.PlayerInfo.Coins; i++)
                _countCoin.Add(_coin);
        }
    }
}