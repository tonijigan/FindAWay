using System;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Save
{
    public class DataSaveWork : MonoBehaviour
    {
        private PlayerData _playerData = new PlayerData();

        public event Action Loaded;

        public int Coins => _playerData.Coins;
        public int ScenesAccess => _playerData.ScenesAccess;

        public void Save(int coins)
        {
            _playerData.Coins = coins;
            SetScenesAccess();
            var json = JsonUtility.ToJson(_playerData);
            PlayerAccount.SetCloudSaveData(json);
        }

        public void Load() => PlayerAccount.GetCloudSaveData(Load);

        private void Load(string value)
        {
            _playerData = JsonUtility.FromJson<PlayerData>(value);
            Loaded?.Invoke();
        }

        private void SetScenesAccess()
        {
            int maxCountScenes = 3;

            if (SceneManager.GetActiveScene().buildIndex >= maxCountScenes) return;

            _playerData.ScenesAccess = SceneManager.GetActiveScene().buildIndex;
        }
    }
}