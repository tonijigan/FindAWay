using System;
using Agava.YandexGames;
using Save;
using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public class ButtonAuthorizationPlayer : AbstractButton
    {
        [SerializeField] private LeaderBoardPanel _leaderBoardPanel;
        [SerializeField] private DataSaveWork _dataSaveWork;

        public event Action<bool> Authorized;

        protected override void OnClick() => Authorization();

        private void Authorization() => PlayerAccount.Authorize(OnSuccessCallback);

        private void OnSuccessCallback()
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            _dataSaveWork.Load();
            Authorized?.Invoke(PlayerAccount.IsAuthorized);
            _leaderBoardPanel.gameObject.SetActive(false);
        }
    }
}