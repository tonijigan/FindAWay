using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class ButtonAuthorizationPlayer : AbstractButton
{
    [SerializeField] private LeaderBoardPanel _leaderBoardPanel;

    public event UnityAction<bool> Authorized;

    protected override void Click() => Authorization();

    private void Authorization()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false) return;

        Authorized?.Invoke(PlayerAccount.IsAuthorized);
        _leaderBoardPanel.gameObject.SetActive(false);
    }
}