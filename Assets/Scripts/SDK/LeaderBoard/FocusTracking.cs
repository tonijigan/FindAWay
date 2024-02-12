using UnityEngine;
using Agava.WebUtility;

public class FocusTracking : MonoBehaviour
{
    [SerializeField] private ButtonAudioListener _buttonAudioListener;
    [SerializeField] private PanelMenu _panelMenu;

    private int _minValue = 0;
    private int _maxValue = 1;

    private void Awake() => Time.timeScale = _maxValue;

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
        if (_panelMenu == null)
            return;

        if (isActive == false)
            _panelMenu.gameObject.SetActive(true);
    }

    private void MuteAudio(bool value)
    {
        if (_buttonAudioListener.IsTurnOn == false)
            AudioListener.pause = value;
    }

    private void PauseGame(bool value)
    {
        if (_panelMenu != null && _panelMenu.isActiveAndEnabled == false)
            Time.timeScale = value ? _minValue : _maxValue;
    }
}