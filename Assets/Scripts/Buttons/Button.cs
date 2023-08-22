using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Transform _boxPoint;

    public event UnityAction<bool> OnDoorClick;

    public Transform BoxPoint => _boxPoint;


    public bool IsClick { get; private set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Box box))
        {
            IsClick = !IsClick;
            OnDoorClick?.Invoke(IsClick);
            _door.WorkDoor();
        }
    }
}
