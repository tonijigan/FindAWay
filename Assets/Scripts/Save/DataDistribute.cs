using UnityEngine;

namespace Save
{
    public class DataDistribute : MonoBehaviour
    {
        [SerializeField] private PlayerDataSaveWork _playerDataSaveWork;
        [SerializeField] private AbstractDataInit[] _initializedObjects;

        private void Awake() => _playerDataSaveWork.Load();

        private void OnEnable() => _playerDataSaveWork.Loaded += OnInitPlayerData;

        private void OnDisable() => _playerDataSaveWork.Loaded -= OnInitPlayerData;

        private void OnInitPlayerData()
        {
            foreach (var initializedObject in _initializedObjects)
                initializedObject.Init(_playerDataSaveWork.Coins);
        }
    }
}