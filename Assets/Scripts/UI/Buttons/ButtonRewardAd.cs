using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ButtonsState))]
public class ButtonRewardAd : AbstractButton
{
    [SerializeField] private TMP_Text _rewardCoins;
    [SerializeField] private ButtonsActive _buttonsActive;
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;

    private ButtonsState _buttonsState;

    private int _countCoins = 10;

    private void Start() => SetValueForReward();

    protected override void Click()
    {
        _buttonsState.DisableButtons(false);
        gameObject.SetActive(false);
        _promotionalVideo.ShowRewardAd();
    }

    private void SetValueForReward()
    {
        _buttonsState = GetComponent<ButtonsState>();
        var result = _countCoins *= _buttonsActive.CountActiveButtons;
        _promotionalVideo.InitReward(result);
        _rewardCoins.text = $"+{result}";
    }
}