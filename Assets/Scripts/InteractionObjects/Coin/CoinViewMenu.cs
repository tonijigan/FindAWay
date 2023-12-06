using TMPro;
using UnityEngine;

public class CoinViewMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Awake() => _text.text = ProgressTest.instance.PlayerInfo.Coin.ToString();
}