using Agava.YandexGames;
using UnityEngine;

public class ButtonAuthorizationPlayer : AbstractButton
{
    [SerializeField] private LeaderBoardPanel _leaderBoardPanel;

    protected override void Click() => Authorization();

    private void Authorization() => PlayerAccount.Authorize(OnSuccessCallback);

    private void OnSuccessCallback()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();
        PlayerAccount.GetCloudSaveData(ProgressInfo.GetPlayerInfo);
        _leaderBoardPanel.gameObject.SetActive(false);
    }
}