using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ChooseScenes : MonoBehaviour
{
    [SerializeField] private ChooseButtonNextScene _nextScene;
    [SerializeField] private ChooseButtonPreviousScene _previousScene;
    [SerializeField] private ChoosedButtonScene _choosedButtonScene;
    [SerializeField] private Image _currentImage;
    [SerializeField] private SceneView[] _scenesView;

    private int _currentImageIndex = 0;

    private void Awake() => ShowCurrentScene();

    private void OnEnable()
    {
        _nextScene.NextScene += ShowNextScene;
        _previousScene.PreviousScene += ShowPreviousScene;
        _choosedButtonScene.OnClick += ChoosedScene;
    }

    private void OnDisable()
    {
        _nextScene.NextScene -= ShowNextScene;
        _previousScene.PreviousScene -= ShowPreviousScene;
        _choosedButtonScene.OnClick -= ChoosedScene;
    }

    private void ChoosedScene() => SceneManager.LoadScene
        (_scenesView[_currentImageIndex].SceneIndex);

    private void ShowNextScene()
    {
        int element = 1;
        int minCount = 0;

        if (_currentImageIndex < _scenesView.Length - element) _currentImageIndex++;
        else _currentImageIndex = minCount;
        ShowCurrentScene();
    }

    private void ShowPreviousScene()
    {
        int element = 1;
        int minCount = 0;

        if (_currentImageIndex > minCount) _currentImageIndex--;
        else _currentImageIndex = _scenesView.Length - element;
        ShowCurrentScene();
    }

    private void ShowCurrentScene()
    {
        _currentImage.sprite = _scenesView[_currentImageIndex].SpriteScene;
        _choosedButtonScene.AccessButton(_scenesView[_currentImageIndex].IsAccess);
        _choosedButtonScene.ShowAccessScene(_scenesView[_currentImageIndex].IsAccess);
    }
}