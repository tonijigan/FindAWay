using System;
using InteractionObjects;
using Player;
using Save;
using UnityEngine;
using Timer = UI.Timer.Timer;

namespace Doors
{
    [RequireComponent(typeof(DoorWithLock))]
    public class DoorLock : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private PlayerDataSaveWork _playerDataSaveWork;
        [SerializeField] private PlayerWallet _wallet;

        private DoorWithLock _doorWithLock;
        private bool _isClose = true;

        public event Action Opened;

        private void Awake() => _doorWithLock = GetComponent<DoorWithLock>();

        public bool TryOpenDoor(InteractionObject interactionObject)
        {
            if (interactionObject == null)
                return _isClose;
            else
            {
                if (!interactionObject.TryGetComponent(out Key key)) return _isClose;
                UseKey(key);

                return _isClose;
            }
        }

        private void UseKey(Key key)
        {
            Destroy(_timer.gameObject);
            _playerDataSaveWork.Save(_wallet.CountCoins);
            key.Enable();
            _doorWithLock.Work();
            Opened?.Invoke();
            _isClose = false;
        }
    }
}