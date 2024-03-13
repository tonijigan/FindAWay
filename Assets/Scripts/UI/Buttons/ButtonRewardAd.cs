using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ButtonRewardAd : AbstractButton
{
    [SerializeField] private TMP_Text _rewardCoins;
    [SerializeField] private ButtonsActive _buttonsActive;
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;

    public event UnityAction<bool> RewardClick;

    private int _countCoins = 10;

    private void Start() => SetValueForReward();

    protected override void Click()
    {
        RewardClick?.Invoke(false);
        gameObject.SetActive(false);
        _promotionalVideo.ShowRewardAd();
    }

    private void SetValueForReward()
    {
        var result = _countCoins *= _buttonsActive.CountActiveButtons;
        _promotionalVideo.InitReward(result);
        _rewardCoins.text = $"+{result}";
    }
}