using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private Door _door;

    public event UnityAction<bool> OnDoorClick;

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
