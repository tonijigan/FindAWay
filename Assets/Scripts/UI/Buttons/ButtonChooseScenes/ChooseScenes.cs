using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ChooseScenes : MonoBehaviour
{
    [SerializeField] private ChooseButtonNextScene _nextScene;
    [SerializeField] private ChooseButtonPreviousScene _previousScene;
    [SerializeField] private ChoosedButtonScene _choosedButtonScene;
    [SerializeField] private Image _currentImage;
    [SerializeField] private SceneView[] _scenesViews;

    private int _currentImageIndex = 0;

    private void Awake() => ShowCurrentScene();

    private void OnEnable()
    {
        ProgressInfo.ReceivedData += InitSave;
        _nextScene.NextScene += ShowNextScene;
        _previousScene.PreviousScene += ShowPreviousScene;
        _choosedButtonScene.OnClick += ChoosedScene;
    }

    private void OnDisable()
    {
        ProgressInfo.ReceivedData -= InitSave;
        _nextScene.NextScene -= ShowNextScene;
        _previousScene.PreviousScene -= ShowPreviousScene;
        _choosedButtonScene.OnClick -= ChoosedScene;
    }

    private void InitSave() => ProgressInfo.Init(_scenesViews);

    private void ChoosedScene() => SceneManager.LoadScene
        (_scenesViews[_currentImageIndex].SceneIndex);

    private void ShowNextScene()
    {
        int element = 1;
        int minCount = 0;

        if (_currentImageIndex < _scenesViews.Length - element) _currentImageIndex++;
        else _currentImageIndex = minCount;
        ShowCurrentScene();
    }

    private void ShowPreviousScene()
    {
        int element = 1;
        int minCount = 0;

        if (_currentImageIndex > minCount) _currentImageIndex--;
        else _currentImageIndex = _scenesViews.Length - element;
        ShowCurrentScene();
    }

    private void ShowCurrentScene()
    {
        _currentImage.sprite = _scenesViews[_currentImageIndex].SpriteScene;
        _choosedButtonScene.AccessButton(_scenesViews[_currentImageIndex].IsAccess);
        _choosedButtonScene.ShowAccessScene(_scenesViews[_currentImageIndex].IsAccess);
    }
}