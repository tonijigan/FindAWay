using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class ButtonAudioListener : AbstractButton
{
    [SerializeField] private Sprite _spriteTurnOffAudio, _spriteTurnOnAudio;

    private Image _image;
    private int _stateTurnOnAudio = 1;
    private bool _isTurnOn;

    private void Awake()
    {
        _isTurnOn = PlayerPrefs.GetInt(HashNames.AudioListenerState)
                                               == _stateTurnOnAudio;
        _image = GetComponent<Image>();
        _image.sprite = _spriteTurnOnAudio;
        ChangeState();
    }
    public override void Click() => ChangeState();

    private void ChangeState()
    {
        _isTurnOn = !_isTurnOn;
        AudioListener.pause = _isTurnOn;

        if (_isTurnOn == true) _image.sprite = _spriteTurnOffAudio;
        else _image.sprite = _spriteTurnOnAudio;

        SaveCurrentState();
    }

    private void SaveCurrentState()
    {
        int stateTurnOffAudio = 0;

        if (_isTurnOn == true)
            PlayerPrefs.SetInt(HashNames.AudioListenerState, stateTurnOffAudio);
        else
            PlayerPrefs.SetInt(HashNames.AudioListenerState, _stateTurnOnAudio);
    }
}