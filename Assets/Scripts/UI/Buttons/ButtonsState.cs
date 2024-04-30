using SDK;
using UnityEngine;

namespace UI.Buttons
{
    public class ButtonsState : MonoBehaviour
    {
        [SerializeField] private AbstractButton[] _abstractButtons;
        [SerializeField] private SDKPromotionalVideo _promotionalVideo;

        private void OnEnable()
        {
            _promotionalVideo.RewardPlayed += OnDisableButtons;
            _promotionalVideo.ClosedCallBack += OnDisableButtons;
        }

        private void OnDisable()
        {
            _promotionalVideo.RewardPlayed -= OnDisableButtons;
            _promotionalVideo.ClosedCallBack -= OnDisableButtons;
        }

        public void OnDisableButtons(bool isReward)
        {
            foreach (var button in _abstractButtons)
                button.enabled = isReward;
        }
    }
}