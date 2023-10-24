using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ChooseScenes : MonoBehaviour
{
    [SerializeField] private ChooseButtonNextScene _nextScene;
    [SerializeField] private ChooseButtonPreviousScene _previousScene;
    [SerializeField] private ChoosedButtonScene _choosedButtonScene;
    [SerializeField] private Image _currentImage;
    [SerializeField] private SceneObject[] _sceneObjects;

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
        (_sceneObjects[_currentImageIndex].SceneIndex);

    private void ShowNextScene()
    {
        int element = 1;
        int minCount = 0;

        if (_currentImageIndex < _sceneObjects.Length - element) _currentImageIndex++;
        else _currentImageIndex = minCount;
        ShowCurrentScene();
    }

    private void ShowPreviousScene()
    {
        int element = 1;
        int minCount = 0;

        if (_currentImageIndex > minCount) _currentImageIndex--;
        else _currentImageIndex = _sceneObjects.Length - element;
        ShowCurrentScene();
    }

    private void ShowCurrentScene() => _currentImage.sprite = _sceneObjects[_currentImageIndex].SpriteScene;
}