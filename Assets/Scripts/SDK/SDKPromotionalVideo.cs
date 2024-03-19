using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SDKPromotionalVideo : MonoBehaviour
{
    [SerializeField] private YandexLeaderBoard _leaderBoard;
    [SerializeField] private FocusTracking _focusTracking;
    [SerializeField] private ButtonAudioListener _buttonAudioListener;

    public event UnityAction<bool> ClosedCallBack, RewardPlayed;

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
        ProgressInfo.RewardCoin(_rewardCoin);
        _leaderBoard.SetScore(ProgressInfo.PlayerInfo.Coins);
        PlayerAccount.SetCloudSaveData(ProgressInfo.JSONString());
    }

    private void OnCloseCallBack()
    {
        Time.timeScale = _minValue;
        _focusTracking.enabled = true;
        RewardPlayed?.Invoke(true);

        if (_buttonAudioListener.IsTurnOn == false)
            AudioListener.volume = _maxValue;
    }

    private void OnCloseCallBack(bool wasShown)
    {
        Time.timeScale = _minValue;
        _focusTracking.enabled = true;
        ClosedCallBack?.Invoke(true);

        if (_buttonAudioListener.IsTurnOn == false)
            AudioListener.volume = _maxValue;
    }
}