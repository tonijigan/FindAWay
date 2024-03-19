using UnityEngine;
using UnityEngine.SceneManagement;

public class InterstitialAdPlay : MonoBehaviour
{
    [SerializeField] private ButtonRestartScene[] _buttonRestartScene;
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;
    [SerializeField] protected int _sceneNumber;

    private void OnEnable()
    {
        foreach (var buttonRestart in _buttonRestartScene)
            buttonRestart.Clicked += PlayPromotionAd;

        _promotionalVideo.ClosedCallBack += LoadScene;
    }

    private void OnDisable()
    {
        foreach (var buttonRestart in _buttonRestartScene)
            buttonRestart.Clicked -= PlayPromotionAd;

        _promotionalVideo.ClosedCallBack -= LoadScene;
    }

    private void PlayPromotionAd() => _promotionalVideo.ShowInterstitialAd();

    private void LoadScene(bool isClosed)
    {
        if (isClosed) SceneManager.LoadScene(_sceneNumber);
    }
}