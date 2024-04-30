using System;
using Agava.YandexGames;
using SDK;
using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public class ButtonAuthorizationPlayer : AbstractButton
    {
        [SerializeField] private LeaderBoardPanel _leaderBoardPanel;

        public event Action<bool> Authorized;

        protected override void OnClick() => Authorization();

        private void Authorization() => PlayerAccount.Authorize(OnSuccessCallback);

        private void OnSuccessCallback()
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            PlayerAccount.GetCloudSaveData(ProgressInfo.GetPlayerInfo);
            Authorized?.Invoke(PlayerAccount.IsAuthorized);
            _leaderBoardPanel.gameObject.SetActive(false);
        }
    }
}