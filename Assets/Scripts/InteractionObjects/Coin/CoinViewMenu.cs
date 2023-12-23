using System;
using TMPro;
using UnityEngine;
using Agava.YandexGames;

public class CoinViewMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private void Awake() =>_text.text = _text.text = StaticCoins.Coins.ToString();
    
}