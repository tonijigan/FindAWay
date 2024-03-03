using TMPro;
using UnityEngine;

public class LeaderBoaredElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerName, _playerScore;

    public void Initialize(string name, int score)
    {
        _playerName.text = name;
        _playerScore.text = score.ToString();
    }
}