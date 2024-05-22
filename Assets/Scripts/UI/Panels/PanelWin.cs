using ButtonGameObject;
using Player;
using SDK.LeaderBoard;
using UnityEngine;

namespace UI.Panels
{
    public class PanelWin : Panel
    {
        [SerializeField] private Transform _pathImageStars;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private YandexLeaderBoard _leaderboard;
        [SerializeField] private ButtonsActive _buttonsActive;
        [SerializeField] private PlayerWallet _playerWallet;

        private Transform[] _imageStars;

        private void Start()
        {
            Initialization();
            Show();
            PlaySound();
            _leaderboard.SetScore(_playerWallet.CountCoins);
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
}