using UI.Buttons.ButtonScene;
using UnityEngine;

namespace SDK.InterstitialAdvertisement
{
    public class InterstitialAdPlay : MonoBehaviour
    {
        [SerializeField] private ButtonRestartScene[] _buttonRestartScene;
        [SerializeField] private SDKPromotionalVideo _promotionalVideo;

        private void OnEnable()
        {
            foreach (var buttonRestart in _buttonRestartScene)
                buttonRestart.Clicked += OnPlayPromotionAd;
        }

        private void OnDisable()
        {
            foreach (var buttonRestart in _buttonRestartScene)
                buttonRestart.Clicked -= OnPlayPromotionAd;
        }

        private void OnPlayPromotionAd() => _promotionalVideo.ShowInterstitialAd();
    }
}