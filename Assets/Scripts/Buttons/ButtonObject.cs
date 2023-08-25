using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonObject : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Transform _boxPoint;

    public event UnityAction<bool> OnDoorClick;

    private Coroutine _coroutine;
    private Vector3 _startButtonPosition;

    public Transform BoxPoint => _boxPoint;
    public bool IsClick { get; private set; } = false;

    private void Awake() => _startButtonPosition = transform.localPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Box box))
            PlayCoroutine();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Box box))
            PlayCoroutine();
    }

    private Vector3 GetPosition()
    {
        float positionZero = 0, newPositionY = -1f;
        var newPosition = transform.localPosition + new Vector3(positionZero, newPositionY, positionZero);

        if (IsClick == true)
            return newPosition;
        else
            return _startButtonPosition;
    }

    private void PlayCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        IsClick = !IsClick;
        _coroutine = StartCoroutine(ChangePosition(GetPosition()));
    }

    private IEnumerator ChangePosition(Vector3 newPosition)
    {
        float duration = 2f;

        while (transform.localPosition != newPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, newPosition, duration * Time.deltaTime);
            yield return null;
        }

        OnDoorClick?.Invoke(IsClick);
        _door.WorkDoor();
        StopCoroutine(ChangePosition(newPosition));
    }
}
