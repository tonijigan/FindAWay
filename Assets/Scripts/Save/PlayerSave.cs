using System;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Save
{
    public class PlayerSave : MonoBehaviour
    {
        private PlayerData _playerData { get; set; } = new PlayerData();

        public event Action Loaded;

        public int Coins => _playerData.Coins;
        public int ScenesAccess => _playerData.ScenesAccess;

        public void Save(int coins)
        {
            _playerData.Coins = coins;

            if (_playerData.ScenesAccess < SceneManager.GetActiveScene().buildIndex && _playerData.ScenesAccess <= 3)
                _playerData.ScenesAccess = SceneManager.GetActiveScene().buildIndex - 1;

            var json = JsonUtility.ToJson(_playerData);
            PlayerAccount.SetCloudSaveData(json);
            Debug.Log(json);
        }

        public void Load() => PlayerAccount.GetCloudSaveData(Load);

        private void Load(string value)
        {
            Debug.Log("ValueData = " + value);
            _playerData = JsonUtility.FromJson<PlayerData>(value);
            Loaded?.Invoke();
        }
    }
}