using Agava.YandexGames;
using UI.Buttons;
using UnityEngine;

namespace UI.Panels
{
    public class LeaderBoardPanel : Panel
    {
        [SerializeField] private AuthorizationPanel _authorizationPanel;
        [SerializeField] private GameObject _leaderBoardPanelView;
        [SerializeField] private ButtonAuthorizationPlayer _buttonAuthorizationPlayer;

        private void Awake() => OnActionPanels(PlayerAccount.IsAuthorized);

        private void OnEnable() => _buttonAuthorizationPlayer.Authorized += OnActionPanels;

        private void OnDisable() => _buttonAuthorizationPlayer.Authorized -= OnActionPanels;

        private void OnActionPanels(bool isAuthorized)
        {
            _authorizationPanel.gameObject.SetActive(false);
            _leaderBoardPanelView.gameObject.SetActive(false);

            if (isAuthorized == false) _authorizationPanel.gameObject.SetActive(true);
            else _leaderBoardPanelView.gameObject.SetActive(true);
        }
    }
}