using UnityEngine;

public class LeaderBoardPlayer : MonoBehaviour
{
    private string _name;
    private int _score;

    public LeaderBoardPlayer(string name, int score)
    {
        _name = name;
        _score = score;
    }

    public string Name => _name;
    public int Score => _score;
}