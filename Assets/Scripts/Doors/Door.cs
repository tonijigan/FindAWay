using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public abstract class Door : MonoBehaviour
{
    [SerializeField] protected Transform _typeDoor;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private float _speedOpenDoor = 1f;
    [SerializeField] private float _waitForSecondsTime;

    protected Vector3 _startPositionDoor;
    protected Vector3 _newPositionDoor;
    private bool _isOpen;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

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
        _playableDirector.Play();
        yield return _waitForSeconds;

        while (_typeDoor.localPosition != target)
        {
            _typeDoor.localPosition = Vector3.MoveTowards(_typeDoor.localPosition, target, _speedOpenDoor * Time.deltaTime);
            yield return null;
        }

        StopCoroutine(MoveDoor(target));
    }
}
