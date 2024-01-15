using UnityEngine;

public class TransitLeaderBoardData : MonoBehaviour
{
    [SerializeField] private LeaderBoard _leaderBoard;

    private void Awake() =>
        _leaderBoard.SetPlayer(ProgressInfo.PlayerInfo.Coins);
}