using UnityEngine;
using UnityEngine.Events;

public class LaserSecurity : MonoBehaviour
{
    [SerializeField] private LaserSecurityDoor _doorLaserSecurity;

    public event UnityAction<bool> IsTrigger;

    private void OnTriggerEnter(Collider other) => Trigger(other);

    private void OnTriggerExit(Collider other) => Trigger(other);

    private void Trigger(Collider collider)
    {
        if (collider != null)
        {
            if (_doorLaserSecurity.IsOpen == false)
                IsTrigger?.Invoke(_doorLaserSecurity.IsOpen);
        }
    }
}
