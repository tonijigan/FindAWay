using Save;
using TMPro;
using UI.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Buttons.ButtonChooseScenes
{
    public class ChooseScenes : MonoBehaviour
    {
        [SerializeField] private ChooseButtonNextScene _nextScene;
        [SerializeField] private ChooseButtonPreviousScene _previousScene;
        [SerializeField] private ChoosedButtonScene _choosedButtonScene;
        [SerializeField] private Image _currentImage;
        [SerializeField] private SceneView[] _scenesViews;
        [SerializeField] private TMP_Text _textNumberScene;
        [SerializeField] private PlayerDataSaveWork _playerDataSaveWork;

        private int _currentImageIndex = 0;
        private int _element = 1;
        private int _minCount = 0;

        private void Awake() => ShowCurrentScene();

        private void OnEnable()
        {
            _playerDataSaveWork.Loaded += OnOpenAccessScenes;
            _nextScene.Clicked += OnShowNextScene;
            _previousScene.Clicked += OnShowPreviousScene;
            _choosedButtonScene.Clicked += OnLoadScene;
        }

        private void OnDisable()
        {
            _playerDataSaveWork.Loaded -= OnOpenAccessScenes;
            _nextScene.Clicked -= OnShowNextScene;
            _previousScene.Clicked -= OnShowPreviousScene;
            _choosedButtonScene.Clicked -= OnLoadScene;
        }

        private void OnOpenAccessScenes()
        {
            for (int i = 0; i < _playerDataSaveWork.ScenesAccess; i++)
                _scenesViews[i].OpenAccess();
        }

        private void OnLoadScene() => SceneManager.LoadScene(_scenesViews[_currentImageIndex].SceneIndex);

        private void OnShowNextScene()
        {
            if (_currentImageIndex < _scenesViews.Length - _element) _currentImageIndex++;
            else _currentImageIndex = _minCount;
            ShowCurrentScene();
        }

        private void OnShowPreviousScene()
        {
            if (_currentImageIndex > _minCount) _currentImageIndex--;
            else _currentImageIndex = _scenesViews.Length - _element;
            ShowCurrentScene();
        }

        private void ShowCurrentScene()
        {
            _currentImage.sprite = _scenesViews[_currentImageIndex].SpriteScene;
            _choosedButtonScene.AccessButton(_scenesViews[_currentImageIndex].IsAccess);
            _choosedButtonScene.ShowAccessScene(_scenesViews[_currentImageIndex].IsAccess);
            _textNumberScene.text = (_currentImageIndex + _element).ToString();
        }
    }
}