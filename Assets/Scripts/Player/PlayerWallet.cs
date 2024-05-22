using System;
using System.Collections.Generic;
using InteractionObjects.Coin;

namespace Player
{
    public class PlayerWallet : AbstractDataInit
    {
        private readonly List<Coin> _countCoin = new List<Coin>();

        public event Action<int> AddedCoin;

        private Coin _coin;

        public int CountCoins => _countCoin.Count;

        public override void Init(int countCoins)
        {
            for (var i = 0; i < countCoins; i++)
                _countCoin.Add(_coin);

            AddedCoin?.Invoke(_countCoin.Count);
        }

        public void RewardCoins(int countRewardCoins)
        {
            for (int i = 0; i < countRewardCoins; i++)
                _countCoin.Add(_coin);

            AddedCoin?.Invoke(_countCoin.Count);
        }

        public void AddCoin(Coin coin)
        {
            _countCoin.Add(coin);
            AddedCoin?.Invoke(_countCoin.Count);
        }
    }
}