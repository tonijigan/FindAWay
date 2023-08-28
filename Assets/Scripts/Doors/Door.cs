using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public abstract class Door : MonoBehaviour
{
    [SerializeField] protected Transform _typeDoor;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private float _speedOpenDoor = 1f, _waitForSecondsTime;

    protected Vector3 StartPositionDoor, NewPositionDoor;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;
    private bool _isOpen;

    public bool IsOpen => _isOpen;

    private void Start()
    {
        SetPosition();
        _waitForSeconds = new WaitForSeconds(_waitForSecondsTime);
    }

    protected abstract Vector3 SetPosition();

    public void WorkDoor()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MoveDoor(GetNextTargetPosition()));
    }

    private Vector3 GetNextTargetPosition()
    {
        if (_isOpen)
            return StartPositionDoor;
        else
            return NewPositionDoor;
    }

    private IEnumerator MoveDoor(Vector3 newxTarget)
    {
        _isOpen = !_isOpen;
        _playableDirector.Play();
        yield return _waitForSeconds;

        while (_typeDoor.localPosition != newxTarget)
        {
            _typeDoor.localPosition = Vector3.MoveTowards(_typeDoor.localPosition, newxTarget, _speedOpenDoor * Time.deltaTime);
            yield return null;
        }

        StopCoroutine(MoveDoor(newxTarget));
    }
}