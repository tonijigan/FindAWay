using Agava.YandexGames;
using UnityEngine;

public class SDKPromotionalVideo : MonoBehaviour
{
    [SerializeField] private LeaderBoard _leaderBoard;

    private int _rewardCoin = 10;

    public void ShowRewardAd() =>
        VideoAd.Show(OnOpenCallBack, OnRewardedCallback, OnCloseCallBack);


    public void ShowInterstitialAd() =>
        InterstitialAd.Show(OnOpenCallBack);


    private void OnOpenCallBack() => AudioListener.volume = 0;


    private void OnRewardedCallback()
    {
        ProgressCoins.RewardCoin(_rewardCoin);
        _leaderBoard.SetPlayer(ProgressCoins.PlayerInfo.Coins);
        PlayerAccount.SetCloudSaveData(ProgressCoins.JSONString());
    }

    private void OnCloseCallBack() => AudioListener.volume = 1;

    // private void OnCloseCallBack(bool wasShown)
    // {
    //    if (wasShown == true)
    //        AudioListener.volume = 1;
    // }
}