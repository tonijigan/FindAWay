using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonAuthorizationPlayer : AbstractButton
{
    [SerializeField] private LeaderBoardPanel _leaderBoardPanel;

    public event UnityAction<bool> Authorized;

    protected override void Click() => Authorization();

    private void Authorization() => PlayerAccount.Authorize(OnSuccessCallback);

    private void OnSuccessCallback()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();
        PlayerAccount.GetCloudSaveData(ProgressInfo.GetPlayerInfo);
        Authorized?.Invoke(PlayerAccount.IsAuthorized);
        _leaderBoardPanel.gameObject.SetActive(false);
    }
}