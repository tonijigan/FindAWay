using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Image))]
    public class ButtonAudioListener : AbstractButton
    {
        private static bool _isTurnOn = false;

        [SerializeField] private Sprite _spriteTurnOffAudio;
        [SerializeField] private Sprite _spriteTurnOnAudio;

        private Image _image;
        private int _stateTurnOffAudio = 0;
        private int _stateTurnOnAudio = 1;

        public bool IsTurnOn => _isTurnOn;

        private void Awake()
        {
            _image = GetComponent<Image>();
            StateImage();
        }

        protected override void OnClick() => ChangeState();

        private void ChangeState()
        {
            _isTurnOn = !_isTurnOn;
            AudioListener.volume = _isTurnOn ? _stateTurnOffAudio : _stateTurnOnAudio;
            StateImage();
        }

        private void StateImage() => _image.sprite = _isTurnOn ? _spriteTurnOffAudio : _spriteTurnOnAudio;
    }
}