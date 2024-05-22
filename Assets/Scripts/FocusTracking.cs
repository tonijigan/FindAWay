using UnityEngine;
using Agava.WebUtility;
using UI.Buttons;
using UI.Panels;

public class FocusTracking : MonoBehaviour
{
    [SerializeField] private ButtonAudioListener _buttonAudioListener;
    [SerializeField] private PanelPause _panelPause;

    private int _minValue = 0;
    private int _maxValue = 1;

    private void Awake()
    {
        Time.timeScale = _maxValue;

        if (_buttonAudioListener.IsTurnOn != false) return;

        AudioListener.pause = false;
        AudioListener.volume = _maxValue;
    }

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
        ActivePanel(inApp);
    }

    private void OnInBackgroundChangeWeb(bool inBackground)
    {
        MuteAudio(inBackground);
        PauseGame(inBackground);
        ActivePanel(inBackground);
    }

    private void ActivePanel(bool isActive)
    {
        if (_panelPause == null)
            return;

        if (isActive == false)
            _panelPause.gameObject.SetActive(true);
    }

    private void MuteAudio(bool value)
    {
        if (_buttonAudioListener.IsTurnOn == false)
            AudioListener.pause = value;
    }

    private void PauseGame(bool value)
    {
        if (_panelPause != null && _panelPause.isActiveAndEnabled == false)
            Time.timeScale = value ? _minValue : _maxValue;
    }
}