using Agava.YandexGames;
using UnityEngine;

public class ButtonOpenLeaderBoard : AbstractButton
{
    [SerializeField] private AbstrapctPanel _leaderBoardPanel;
    public override void Click()
    {
        _leaderBoardPanel.gameObject.SetActive(true);
#if UNITY_WEBGL && !UNITY_EDITOR
        Open();
#endif
    }

    private void Open()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
        }

        if (PlayerAccount.IsAuthorized == false)
            return;
    }
}