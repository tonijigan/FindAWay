using System;
using Doors;
using UI.Timer;
using UnityEngine;

namespace AlarmSystem
{
    public class LaserSecurity : MonoBehaviour
    {
        [SerializeField] private DoorLaserSecurity _doorLaserSecurity;
        [SerializeField] private Timer _timer;

        private bool _isTrigger;

        public event Action<bool> IsTriggered;

        private void OnTriggerEnter(Collider collider)
        {
            if (!_isTrigger && _doorLaserSecurity.IsOpen == false)
            {
                _timer.SetNewTime();
                IsTriggered?.Invoke(_doorLaserSecurity.IsOpen);
            }

            _isTrigger = true;
        }
    }
}