using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public abstract class AbstractButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _audioSource;

        protected Button ButtonUI => _button;

        private void OnEnable() => _button.onClick.AddListener(OnButtonClick);

        private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

        public void AccessButton(bool isAccess) => _button.interactable = isAccess;

        protected abstract void OnClick();

        private void PlaySound() => _audioSource.Play();

        private void OnButtonClick()
        {
            PlaySound();
            OnClick();
        }
    }
}