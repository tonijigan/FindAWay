using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public abstract class AbstractButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _audioSource;

        protected Button ButtonUI => _button;

        private void OnEnable() => _button.onClick.AddListener(ButtonClick);

        private void OnDisable() => _button.onClick.RemoveListener(ButtonClick);

        protected abstract void OnClick();

        public void AccessButton(bool isAccess) => _button.interactable = isAccess;

        private void PlaySound() => _audioSource.Play();

        private void ButtonClick()
        {
            PlaySound();
            OnClick();
        }
    }
}