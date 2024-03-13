using System;
using Agava.YandexGames;
using UnityEngine;

public class LeaderBoardPanel : AbstrapctPanel
{
    [SerializeField] private AuthorizationPanel _authorizationPanel;
    [SerializeField] private GameObject _leaderBoardPanelView;
    [SerializeField] private ButtonAuthorizationPlayer _buttonAuthorizationPlayer;

    private void Awake() => HaveAuthorization(PlayerAccount.IsAuthorized);

    private void OnEnable() => _buttonAuthorizationPlayer.Authorized += HaveAuthorization;

    private void OnDisable() => _buttonAuthorizationPlayer.Authorized -= HaveAuthorization;

    private void HaveAuthorization(bool isAuthorized)
    {
        _authorizationPanel.gameObject.SetActive(false);
        _leaderBoardPanelView.gameObject.SetActive(false);

        if (isAuthorized == false) _authorizationPanel.gameObject.SetActive(true);
        else _leaderBoardPanelView.gameObject.SetActive(true);
    }
}