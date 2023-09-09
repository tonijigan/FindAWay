using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public abstract class Door : MonoBehaviour
{
    [SerializeField] protected Transform _typeDoor;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private float _speedOpenDoor = 1f, _waitForSecondsTime;

    protected Vector3 StartPositionDoor, NewPositionDoor;
    protected Coroutine Coroutine;
    protected bool IsOpenDoor;

    private WaitForSeconds _waitForSeconds;

    public bool IsOpen => IsOpenDoor;

    private void Start()
    {
        SetPosition();
        _waitForSeconds = new WaitForSeconds(_waitForSecondsTime);
    }

    protected abstract void SetPosition();

    public void WorkDoor()
    {
        if (Coroutine != null)
            StopCoroutine(Coroutine);

        Coroutine = StartCoroutine(MoveDoor(GetNextTargetPosition()));
    }

    private Vector3 GetNextTargetPosition()
    {
        if (IsOpenDoor)
            return StartPositionDoor;
        else
            return NewPositionDoor;
    }

    public virtual IEnumerator MoveDoor(Vector3 newxTarget)
    {
        IsOpenDoor = !IsOpenDoor;
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