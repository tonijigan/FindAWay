using TMPro;
using UnityEngine;

public class ButtonRewardAd : AbstractButton
{
    [SerializeField] private TMP_Text _rewardCoins;
    [SerializeField] private ButtonsActive _buttonsActive;
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;

    private int _countCoins = 10;
    
    private void Start() => SetValueForReward();

    protected override void Click()
    {
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