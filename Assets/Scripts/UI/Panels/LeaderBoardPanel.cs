using UnityEngine;

public class LeaderBoardPanel : AbstrapctPanel
{
    [SerializeField] private LeaderBoard _leaderBoard;

    private void Awake() =>
        _leaderBoard.SetPlayer(PlayerPrefs.GetInt(HashNames.Coins));

}