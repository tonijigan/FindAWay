using System.Collections;
using UnityEngine;

public abstract class Door : MonoBehaviour
{
    [SerializeField] protected Transform _typeDoor;
    [SerializeField] private float _speedOpenDoor = 1f;

    protected Vector3 _startPositionDoor;
    protected Vector3 _newPositionDoor;
    private bool _isOpen;

    private Coroutine _coroutine;

    public bool IsOpen => _isOpen;

    private void Start() => SetPosition();

    protected abstract Vector3 SetPosition();

    public void WorkDoor()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MoveDoor(GetTarget()));
    }

    private Vector3 GetTarget()
    {
        if (_isOpen)
            return _startPositionDoor;
        else
            return _newPositionDoor;
    }

    private IEnumerator MoveDoor(Vector3 target)
    {
        _isOpen = !_isOpen;

        while (_typeDoor.transform.position != target)
        {
            _typeDoor.transform.position = Vector3.MoveTowards(_typeDoor.transform.position, target, _speedOpenDoor * Time.deltaTime);
            yield return null;
        }

        StopCoroutine(MoveDoor(target));
    }
}
