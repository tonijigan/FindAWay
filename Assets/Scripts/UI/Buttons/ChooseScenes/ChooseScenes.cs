using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseScenes : MonoBehaviour
{
    [SerializeField] private ChooseButtonNextScene _nextScene;
    [SerializeField] private ChooseButtonPreviousScene _previousScene;
    [SerializeField] private Transform _imagesPath;

    private Transform[] _count;
    private int _currentImage = 0;

    private void Awake() => Initialization();

    private void OnEnable()
    {
        _nextScene.NextScene += ShowNextScene;
        _previousScene.PreviousScene += ShowPreviousScene;
    }

    private void OnDisable()
    {
        _nextScene.NextScene -= ShowNextScene;
        _previousScene.PreviousScene -= ShowPreviousScene;
    }

    private void Initialization()
    {
        _count = new Transform[_imagesPath.childCount];

        for (int i = 0; i < _count.Length; i++)
            _count[i] = _imagesPath.GetChild(i);

        ShowCurrentScene();
    }

    private void ShowNextScene()
    {
        int element = 1;
        int minCount = 0;

        if (_currentImage < _count.Length - element) _currentImage++;
        else _currentImage = minCount;
        ShowCurrentScene();
    }

    private void ShowPreviousScene()
    {
        int element = 1;
        int minCount = 0;

        if (_currentImage > minCount) _currentImage--;
        else _currentImage = _count.Length - element;
        ShowCurrentScene();
    }

    private void ShowCurrentScene()
    {
        for (int i = 0; i < _count.Length; i++)
            _count[i].gameObject.SetActive(false);

        _count[_currentImage].gameObject.SetActive(true);
    }
}