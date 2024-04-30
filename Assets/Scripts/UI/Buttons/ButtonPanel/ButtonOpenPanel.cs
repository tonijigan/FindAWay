using SimpleInputNamespace;
using UI.Panels;
using UnityEngine;

namespace UI.Buttons.ButtonPanel
{
    public class ButtonOpenPanel : AbstractButton
    {
        [SerializeField] private Panel _panel;
        [SerializeField] private Joystick _joystick;

        protected override void OnClick() => OpenPanel();

        private void OpenPanel()
        {
            var timeScale = 0f;
            _panel.gameObject.SetActive(true);
            _joystick.gameObject.SetActive(false);
            Time.timeScale = timeScale;
        }
    }
}