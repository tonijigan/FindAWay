using Agava.YandexGames;
using UnityEngine;

public class SDKPromotionalVideo : MonoBehaviour
{
    [SerializeField] private LeaderBoard _leaderBoard;
    [SerializeField] private AudioSource[] _audioSources;

    private int _rewardCoin = 10;
    private int _minValue = 0;
    private int _maxValue = 1;

    public void ShowRewardAd() =>
        VideoAd.Show(OnOpenCallBack, OnRewardedCallback, OnCloseCallBack);


    public void ShowInterstitialAd() =>
        InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);

    public void InitReward(int reward) => _rewardCoin = reward;

    private void OnOpenCallBack() =>
        ChangeValueAudioSources(_minValue);


    private void OnRewardedCallback()
    {
        ProgressInfo.RewardCoin(_rewardCoin);
        _leaderBoard.SetPlayer(ProgressInfo.PlayerInfo.Coins);
        PlayerAccount.SetCloudSaveData(ProgressInfo.JSONString());
    }

    private void OnCloseCallBack()
    {
        ChangeValueAudioSources(_maxValue);
        Time.timeScale = _minValue;
    }

    private void OnCloseCallBack(bool wasShown)
    {
        if (wasShown == true)
            ChangeValueAudioSources(_maxValue);

        Time.timeScale = _minValue;
    }

    private void ChangeValueAudioSources(int value)
    {
        foreach (var audioSource in _audioSources)
            audioSource.volume = value;
    }
}