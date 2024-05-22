using System;
using Agava.YandexGames;
using Player;
using Save;
using SDK.LeaderBoard;
using UI.Buttons;
using UnityEngine;

namespace SDK
{
    public class SDKPromotionalVideo : MonoBehaviour
    {
        [SerializeField] private YandexLeaderBoard _leaderBoard;
        [SerializeField] private FocusTracking _focusTracking;
        [SerializeField] private ButtonAudioListener _buttonAudioListener;
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private DataSaveWork _dataSaveWork;

        public event Action<bool> ClosedCallBack, RewardPlayed;

        private int _rewardCoin = 10;
        private int _minValue = 0;
        private int _maxValue = 1;

        public void ShowRewardAd() =>
            VideoAd.Show(OnOpenCallBack, OnRewardedCallback, OnCloseCallBack);

        public void ShowInterstitialAd() =>
            InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);

        public void InitReward(int reward) => _rewardCoin = reward;

        private void OnOpenCallBack()
        {
            Time.timeScale = _minValue;
            _focusTracking.enabled = false;
            AudioListener.volume = _minValue;
        }


        private void OnRewardedCallback()
        {
            _playerWallet.RewardCoins(_rewardCoin);
            _leaderBoard.SetScore(_playerWallet.CountCoins);
            _dataSaveWork.Save(_playerWallet.CountCoins);
        }

        private void OnCloseCallBack() => CloseCallBack(RewardPlayed);

        private void OnCloseCallBack(bool wasShown) => CloseCallBack(ClosedCallBack);

        private void CloseCallBack(Action<bool> action)
        {
            Time.timeScale = _minValue;
            _focusTracking.enabled = true;
            action?.Invoke(true);

            if (_buttonAudioListener.IsTurnOn == false)
                AudioListener.volume = _maxValue;
        }
    }
}