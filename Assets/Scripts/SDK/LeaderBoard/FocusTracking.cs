using UnityEngine;
using Agava.WebUtility;

public class FocusTracking : MonoBehaviour
{
    [SerializeField] private ButtonAudioListener _buttonAudioListener;
    [SerializeField] private PanelPlayGame _panelPlayGame;

    private int _minValue = 0;
    private int _maxValue = 1;

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        MuteAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeWeb(bool inBackground)
    {
        MuteAudio(inBackground);
        PauseGame(inBackground);
    }

    private void MuteAudio(bool value)
    {
        if (_buttonAudioListener.IsTurnOn == false)
            AudioListener.pause = value;
    }

    private void PauseGame(bool value)
    {
        if (_panelPlayGame != null && _panelPlayGame.isActiveAndEnabled == false)
            Time.timeScale = value ? _minValue : _maxValue;
    }
}