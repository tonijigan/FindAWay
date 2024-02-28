using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ChooseScenes : MonoBehaviour
{
    [SerializeField] private ChooseButtonNextScene _nextScene;
    [SerializeField] private ChooseButtonPreviousScene _previousScene;
    [SerializeField] private ChoosedButtonScene _choosedButtonScene;
    [SerializeField] private Image _currentImage;
    [SerializeField] private SceneView[] _scenesViews;
    [SerializeField] private TMP_Text _textNumberScene;

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
        var element = 1;
        var minCount = 0;

        if (_currentImageIndex < _scenesViews.Length - element) _currentImageIndex++;
        else _currentImageIndex = minCount;
        ShowCurrentScene();
    }

    private void ShowPreviousScene()
    {
        var element = 1;
        var minCount = 0;

        if (_currentImageIndex > minCount) _currentImageIndex--;
        else _currentImageIndex = _scenesViews.Length - element;
        ShowCurrentScene();
    }

    private void ShowCurrentScene()
    {
        var element = 1;
        _currentImage.sprite = _scenesViews[_currentImageIndex].SpriteScene;
        _choosedButtonScene.AccessButton(_scenesViews[_currentImageIndex].IsAccess);
        _choosedButtonScene.ShowAccessScene(_scenesViews[_currentImageIndex].IsAccess);
        _textNumberScene.text = (_currentImageIndex + element).ToString();
    }
}