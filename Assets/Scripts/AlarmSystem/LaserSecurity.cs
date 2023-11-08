using UnityEngine;
using UnityEngine.Events;

public class LaserSecurity : MonoBehaviour
{
    [SerializeField] private LaserSecurityDoor _doorLaserSecurity;
    [SerializeField] private Timer _timer;

    public event UnityAction<bool> IsTrigger;

    private bool _isTrigger = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider != null && _isTrigger == false)
        {
            _isTrigger = true;
            _timer.SetNewTime();
            if (_doorLaserSecurity.IsOpen == false)
                IsTrigger?.Invoke(_doorLaserSecurity.IsOpen);
        }
    }
}