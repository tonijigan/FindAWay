using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Image))]
    public class ButtonAudioListener : AbstractButton
    {
        [SerializeField] private Sprite _spriteTurnOffAudio, _spriteTurnOnAudio;

        private static bool s_isTurnOn = false;

        private Image _image;
        private int _stateTurnOffAudio = 0;
        private int _stateTurnOnAudio = 1;

        public bool IsTurnOn => s_isTurnOn;

        private void Awake()
        {
            _image = GetComponent<Image>();
            StateImage();
        }

        protected override void OnClick() => ChangeState();

        private void ChangeState()
        {
            s_isTurnOn = !s_isTurnOn;
            AudioListener.volume = s_isTurnOn ? _stateTurnOffAudio : _stateTurnOnAudio;
            StateImage();
        }

        private void StateImage() => _image.sprite = s_isTurnOn ? _spriteTurnOffAudio : _spriteTurnOnAudio;
    }
}