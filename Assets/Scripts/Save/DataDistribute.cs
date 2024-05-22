using UnityEngine;

namespace Save
{
    public class DataDistribute : MonoBehaviour
    {
        [SerializeField] private DataSaveWork _dataSaveWork;
        [SerializeField] private AbstractDataInit[] _initializedObjects;

        private void Awake() => _dataSaveWork.Load();

        private void OnEnable() => _dataSaveWork.Loaded += InitData;

        private void OnDisable() => _dataSaveWork.Loaded -= InitData;

        private void InitData()
        {
            foreach (var initializedObject in _initializedObjects)
                initializedObject.Init(_dataSaveWork.Coins);
        }
    }
}