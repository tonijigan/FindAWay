using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class SDKPromotionalVideo : MonoBehaviour
{
    [SerializeField] private YandexLeaderBoard _leaderBoard;
    [SerializeField] private FocusTracking _focusTracking;
    public event UnityAction ClosedCallBack;

    private int _rewardCoin = 10;
    private int _minValue = 0;

    public void ShowRewardAd() =>
        VideoAd.Show(OnOpenCallBack, OnRewardedCallback, OnCloseCallBack);

    public void ShowInterstitialAd() =>
        InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);

    public void InitReward(int reward) => _rewardCoin = reward;

    private void OnOpenCallBack()
    {
        AudioListener.pause = true;
        _focusTracking.enabled = false;
        Time.timeScale = _minValue;
    }


    private void OnRewardedCallback()
    {
        ProgressInfo.RewardCoin(_rewardCoin);
        _leaderBoard.SetScore(ProgressInfo.PlayerInfo.Coins);
        PlayerAccount.SetCloudSaveData(ProgressInfo.JSONString());
    }

    private void OnCloseCallBack()
    {
        AudioListener.pause = false;
        _focusTracking.enabled = true;
        Time.timeScale = _minValue;
    }

    private void OnCloseCallBack(bool wasShown)
    {
        if (wasShown == true)
            AudioListener.pause = false;

        _focusTracking.enabled = true;
        Time.timeScale = _minValue;
        ClosedCallBack?.Invoke();
    }
}