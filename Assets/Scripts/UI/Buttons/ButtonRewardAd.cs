using ButtonGameObject;
using SDK;
using TMPro;
using UnityEngine;

namespace UI.Buttons
{
    [RequireComponent(typeof(ButtonsState))]
    public class ButtonRewardAd : AbstractButton
    {
        [SerializeField] private TMP_Text _rewardCoins;
        [SerializeField] private ButtonsActive _buttonsActive;
        [SerializeField] private SDKPromotionalVideo _promotionalVideo;

        private ButtonsState _buttonsState;

        private int _countCoins = 10;

        private void Start() => SetValueForReward();

        protected override void OnClick()
        {
            _buttonsState.OnDisableButtons(false);
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
}