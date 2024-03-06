using Agava.YandexGames;
using UnityEngine;

public class LeaderBoardPanel : AbstrapctPanel
{
    [SerializeField] private AuthorizationPanel _authorizationPanel;
    [SerializeField] private GameObject _leaderBoardPanelView;

    private void Awake() => HaveAuthorization(PlayerAccount.IsAuthorized);
    
    private void HaveAuthorization(bool isAuthorized)
    {
        if (isAuthorized == false) _authorizationPanel.gameObject.SetActive(true);
        else _leaderBoardPanelView.gameObject.SetActive(true);
    }
}