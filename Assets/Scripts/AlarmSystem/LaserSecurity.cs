using UnityEngine;
using UnityEngine.Events;

public class LaserSecurity : MonoBehaviour
{
    [SerializeField] private LaserSecurityDoor _doorLaserSecurity;
    [SerializeField] private Timer _timer;

    public event UnityAction<bool> IsTrigger;

    private void OnTriggerEnter(Collider collider)
    {
        if (_doorLaserSecurity.IsOpen == false)
        {
            _timer.SetNewTime();
            IsTrigger?.Invoke(_doorLaserSecurity.IsOpen);
        }
    }
}