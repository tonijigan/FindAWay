using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Buttons.ButtonScene
{
    public class ButtonScene : AbstractButton
    {
        [SerializeField] private int _sceneNumber;

        private float _wait = 0.1f;

        protected override void OnClick() => WorkScene();

        public void Load() => SceneManager.LoadScene(_sceneNumber);

        private void WorkScene()
        {
            var timeScale = 1.0f;
            Time.timeScale = timeScale;
            Invoke(HashedStrings.Load, _wait);
        }
    }
}