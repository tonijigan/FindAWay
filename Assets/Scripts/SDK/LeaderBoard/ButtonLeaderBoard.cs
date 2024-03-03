using UnityEngine;

public class ButtonLeaderBoard : AbstractButton
{
    [SerializeField] private LeaderBoardPanel _leaderBoardPanel;

    protected override void Click() => _leaderBoardPanel.gameObject.SetActive(true);
}