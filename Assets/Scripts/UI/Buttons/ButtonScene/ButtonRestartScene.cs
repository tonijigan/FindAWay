using System;
using UnityEngine;

namespace UI.Buttons.ButtonScene
{
    [RequireComponent(typeof(ButtonsState))]
    public class ButtonRestartScene : AbstractButton
    {
        public event Action Clicked;

        private ButtonsState _buttonsState;

        private void Start() => _buttonsState = GetComponent<ButtonsState>();

        protected override void OnClick() => WorkScene();

        private void WorkScene()
        {
            Clicked?.Invoke();
            _buttonsState.OnDisableButtons(false);
            float timeScale = 1.0f;
            Time.timeScale = timeScale;
        }
    }
}