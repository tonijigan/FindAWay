using TMPro;
using UnityEngine;

public class LeaderBoardElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _PlayerCoins;

    public void Initialize(string name, int coins)
    {
        _playerName.text = name;
        _PlayerCoins.text = coins.ToString();
    }
}