using UnityEngine;
using UnityEngine.SceneManagement;

public class InterstitialAdPlay : MonoBehaviour
{
    [SerializeField] private ButtonRestartScene[] _buttonRestartScene;
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;
    [SerializeField] protected int _sceneNumber;

    private void OnEnable()
    {
        for (int i = 0; i < _buttonRestartScene.Length; i++)
            _buttonRestartScene[i].Clicked += PlayPromotionAd;

        _promotionalVideo.ClosedCallBack += loadScene;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buttonRestartScene.Length; i++)
            _buttonRestartScene[i].Clicked -= PlayPromotionAd;

        _promotionalVideo.ClosedCallBack -= loadScene;
    }

    private void PlayPromotionAd() => _promotionalVideo.ShowInterstitialAd();

    private void loadScene() => SceneManager.LoadScene(_sceneNumber);
}