using System;
using UnityEngine;

public class LaserSecurity : MonoBehaviour
{
    [SerializeField] private DoorLaserSecurity _doorLaserSecurity;
    [SerializeField] private Timer _timer;

    public event Action<bool> IsTriggered;

    private bool _isTrigger;

    private void OnTriggerEnter(Collider collider)
    {
        if (!_isTrigger && _doorLaserSecurity.IsOpened == false)
        {
            _timer.SetNewTime();
            IsTriggered?.Invoke(_doorLaserSecurity.IsOpened);
        }

        _isTrigger = true;
    }
}