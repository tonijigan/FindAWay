using Agava.YandexGames;
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
        PlayerAccount.SetCloudSaveData(ProgressInfo.JSONString());
#endif
        Initialization();
        Show();
        PlaySound();
        _leaderboard.SetPlayer(ProgressInfo.PlayerInfo.Coins);
    }

    private void Initialization()
    {
        _imageStars = new Transform[_pathImageStars.childCount];

        for (int i = 0; i < _pathImageStars.childCount; i++)
            _imageStars[i] = _pathImageStars.GetChild(i);

        for (int i = 0; i < _imageStars.Length; i++)
            _imageStars[i].gameObject.SetActive(false);
    }

    private void Show()
    {
        int element = 1;
        _imageStars[_buttonsActive.CountActiveButtons - element].gameObject.SetActive(true);
    }

    private void PlaySound()
    {
        _audioSource.loop = false;
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}