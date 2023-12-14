using UnityEngine;

public class SDKPromotionalVideo : MonoBehaviour
{
    private int _money;
    private int _minValue = 0;
    private int _maxValue = 1;

    public void Show() =>
        Agava.YandexGames.VideoAd.Show(OnOpenCallBack, OnRewardCallBack, OnCloseCallBack);

    private void OnOpenCallBack() => SateGame(_minValue);

    private void OnRewardCallBack() => _money++;

    private void OnCloseCallBack() => SateGame(_maxValue);

    private void SateGame(int stateValue) => AudioListener.volume = stateValue;
}