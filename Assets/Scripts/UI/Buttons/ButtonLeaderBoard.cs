using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public class ButtonLeaderBoard : AbstractButton
    {
        [SerializeField] private LeaderBoardPanel _leaderBoardPanel;

        protected override void OnClick() => _leaderBoardPanel.gameObject.SetActive(true);
    }
}