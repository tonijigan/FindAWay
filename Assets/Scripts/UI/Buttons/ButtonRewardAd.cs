using TMPro;
using UnityEngine;

[RequireComponent(typeof(SDKPromotionalVideo))]
public class ButtonRewardAd : AbstractButton
{
    [SerializeField] private TMP_Text _rewardCoins;
    [SerializeField] private PanelWin _panelWin;

    private SDKPromotionalVideo _promotionalVideo;
    private int _countCoins = 10;

    private void Awake() =>  _promotionalVideo = GetComponent<SDKPromotionalVideo>();

    private void Start() => SetValueForReward();

    public override void Click()
    {
        gameObject.SetActive(false);
        _promotionalVideo.ShowRewardAd();
    }

    private void SetValueForReward() => _rewardCoins.text = $"+{_countCoins *= _panelWin.CountButtonIsClick}";
}