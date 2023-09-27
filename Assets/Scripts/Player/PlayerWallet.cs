using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private List<Coin> _countCoin = new List<Coin>();

    public event UnityAction<int> AddedCoin;

    public void AddCoin(Coin coin)
    {
        _countCoin.Add(coin);
        AddedCoin?.Invoke(_countCoin.Count);
    }
}