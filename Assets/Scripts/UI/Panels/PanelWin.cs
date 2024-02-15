using UnityEngine;

public class PanelWin : AbstrapctPanel
{
    [SerializeField] private Transform _pathImageStars;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private LeaderBoard _leaderboard;
    [SerializeField] private ButtonsActive _buttonsActive;

    private Transform[] _imageStars;

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.PlayerAccount.SetCloudSaveData(ProgressInfo.JSONString());
#endif
        Initialization();
        Show();
        PlaySound();
        _leaderboard.SetScore(ProgressInfo.PlayerInfo.Coins);
    }

    private void Initialization()
    {
        _imageStars = new Transform[_pathImageStars.childCount];

        for (var i = 0; i < _pathImageStars.childCount; i++)
            _imageStars[i] = _pathImageStars.GetChild(i);

        foreach (var star in _imageStars)
            star.gameObject.SetActive(false);
    }

    private void Show()
    {
        var element = 1;
        _imageStars[_buttonsActive.CountActiveButtons - element].gameObject.SetActive(true);
    }

    private void PlaySound()
    {
        _audioSource.loop = false;
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}