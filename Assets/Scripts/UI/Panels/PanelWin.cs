using System;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class PanelWin : AbstrapctPanel
{
    [SerializeField] private Transform _pathImageStars;
    [SerializeField] private ButtonObject[] _buttons;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private LeaderBoard _leaderboard;

    private Transform[] _imageStars;

    public int CountButtonIsClick { get; private set; } = 0;

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.SetCloudSaveData(ProgressCoins.JSONString());
#endif
        Initialization();
        Show();
        PlaySound();
        _leaderboard.SetPlayer(ProgressCoins.PlayerInfo.Coins);
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
        int minCountButtonIsClick = 0;
        int element = 1;

        for (int i = 0; i < _buttons.Length; i++)
            if (_buttons[i].IsClick)
                CountButtonIsClick++;

        if (CountButtonIsClick == minCountButtonIsClick)
            return;

        _imageStars[CountButtonIsClick - element].gameObject.SetActive(true);
    }

    private void PlaySound()
    {
        _audioSource.loop = false;
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}