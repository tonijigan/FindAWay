using UnityEngine;

public class PanelWin : AbstrapctPanel
{
    [SerializeField] private Transform _pathImageStars;
    [SerializeField] private SceneObject _sceneObject;
    [SerializeField] private ButtonObject[] _buttons;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;

    private Transform[] _imageStars;
    private int _countButtonIsClick = 0;

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        _promotionalVideo.Show();
#endif
        Initialization();
        OpenAccessNextScene();
        Show();
        PlaySound();
    }

    private void Initialization()
    {
        _imageStars = new Transform[_pathImageStars.childCount];

        for (int i = 0; i < _pathImageStars.childCount; i++)
            _imageStars[i] = _pathImageStars.GetChild(i);

        for (int i = 0; i < _imageStars.Length; i++)
            _imageStars[i].gameObject.SetActive(false);
    }

    private void OpenAccessNextScene()
    {
        int _accessStatusTrue = 1;

        if (_sceneObject != null && PlayerPrefs.GetInt(_sceneObject.name) != _accessStatusTrue)
            PlayerPrefs.SetInt(_sceneObject.name, _accessStatusTrue);
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

    private void PlaySound()
    {
        _audioSource.loop = false;
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}