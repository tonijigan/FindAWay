using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonObject : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Transform _boxPoint, _button;

    public event UnityAction<bool> OnDoorClick;

    public Transform BoxPoint => _boxPoint;

    public bool IsClick { get; private set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Box box))
            StartCoroutine(ChangePosition());
    }

    private IEnumerator ChangePosition()
    {
        float positionZero = 0, newPositionY = -1f, duration = 2f;
        var newPosition = _button.localPosition + new Vector3(positionZero, newPositionY, positionZero);
        IsClick = !IsClick;

        while (_button.localPosition != newPosition)
        {
            _button.localPosition = Vector3.MoveTowards(_button.localPosition, newPosition, duration * Time.deltaTime);
            yield return null;
        }

        OnDoorClick?.Invoke(IsClick);
        _door.WorkDoor();
        StopCoroutine(ChangePosition());
    }
}
