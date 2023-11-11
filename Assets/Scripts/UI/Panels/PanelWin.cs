using UnityEngine;

public class PanelWin : AbstrapctPanel
{
    [SerializeField] private Transform _pathImageStars;
    [SerializeField] private ButtonObject[] _buttons;
    [SerializeField] private SceneObject _nextSceneObject;

    private Transform[] _imageStars;
    private int _countButtonIsClick = 0;

    private void Start()
    {
        Initialization();
        OpenNextScene();
        Show();
    }

    private void Initialization()
    {
        _imageStars = new Transform[_pathImageStars.childCount];

        for (int i = 0; i < _pathImageStars.childCount; i++)
            _imageStars[i] = _pathImageStars.GetChild(i);

        for (int i = 0; i < _imageStars.Length; i++)
            _imageStars[i].gameObject.SetActive(false);
    }

    private void OpenNextScene()
    {
        if (_nextSceneObject == null)
            return;

        _nextSceneObject.OpenAccess();
    }

    private void Show()
    {
        int minCountButtonIsClick = 0;
        int element = 1;

        for (int i = 0; i < _buttons.Length; i++)
            if (_buttons[i].IsClick)
                _countButtonIsClick++;

        if (_countButtonIsClick == minCountButtonIsClick)
            return;

        _imageStars[_countButtonIsClick - element].gameObject.SetActive(true);
    }
}