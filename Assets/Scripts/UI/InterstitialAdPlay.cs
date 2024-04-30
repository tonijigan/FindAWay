using SDK;
using UI.Buttons.ButtonScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class InterstitialAdPlay : MonoBehaviour
    {
        [SerializeField] private ButtonRestartScene[] _buttonRestartScene;
        [SerializeField] private SDKPromotionalVideo _promotionalVideo;
        [SerializeField] protected int _sceneNumber;

        private void OnEnable()
        {
            foreach (var buttonRestart in _buttonRestartScene)
                buttonRestart.Clicked += OnPlayPromotionAd;

            _promotionalVideo.ClosedCallBack += OnLoadScene;
        }

        private void OnDisable()
        {
            foreach (var buttonRestart in _buttonRestartScene)
                buttonRestart.Clicked -= OnPlayPromotionAd;

            _promotionalVideo.ClosedCallBack -= OnLoadScene;
        }

        private void OnPlayPromotionAd() => _promotionalVideo.ShowInterstitialAd();

        private void OnLoadScene(bool isClosed)
        {
            if (isClosed) SceneManager.LoadScene(_sceneNumber);
        }
    }
}