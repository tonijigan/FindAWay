using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Buttons.ButtonScene
{
    public class ButtonScene : AbstractButton
    {
        [SerializeField] protected int _sceneNumber;

        private float _wait = 0.1f;

        protected override void OnClick() => WorkScene();

        private void WorkScene()
        {
            var timeScale = 1.0f;
            Time.timeScale = timeScale;
            Invoke(HashedStrings.Load, _wait);
        }

        public void Load() => SceneManager.LoadScene(_sceneNumber);
    }
}