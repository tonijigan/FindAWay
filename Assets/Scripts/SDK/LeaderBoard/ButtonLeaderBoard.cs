using Agava.YandexGames;
using UnityEngine;

public class ButtonLeaderBoard : AbstractButton
{
    [SerializeField] private AbstrapctPanel _AutorizationPanel, _leaderBoardPanel;

    protected override void Click() => OpenLeaderBoard();

    private void OpenLeaderBoard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
            return;
    }
}