using System;

namespace UI.Buttons.ButtonChooseScenes
{
    public class ChooseButtonPreviousScene : AbstractButton
    {
        public event Action Clicked;

        protected override void OnClick() => ShowPreviousScene();

        private void ShowPreviousScene() => Clicked?.Invoke();
    }
}