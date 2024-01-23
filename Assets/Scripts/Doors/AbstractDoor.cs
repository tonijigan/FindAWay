using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public abstract class AbstractDoor : MonoBehaviour
{
    [SerializeField] protected Transform _typeDoor;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private float _speedOpenDoor = 1f, _waitForSecondsTime;
    [SerializeField] private AudioSource _doorAudioSource;
    [SerializeField] private AudioClip _doorClip;

    protected Vector3 StartPositionDoor, NewPositionDoor;
    protected Coroutine Coroutine;
    protected WaitForSeconds WaitForSeconds;
    protected bool IsOpenDoor;

    protected AudioSource AudioDoor => _doorAudioSource;
    protected AudioClip AudioClip => _doorClip;

    public bool IsOpen => IsOpenDoor;

    protected PlayableDirector PlayableDirector => _playableDirector;

    private void Start()
    {
        SetPosition();
        WaitForSeconds = new WaitForSeconds(_waitForSecondsTime);
    }

    protected abstract void SetPosition();

    public void WorkDoor()
    {
        if (Coroutine != null)
            StopCoroutine(Coroutine);

        Coroutine = StartCoroutine(MoveDoor(GetNextTargetPosition()));
    }

    protected virtual IEnumerator MoveDoor(Vector3 newTarget)
    {
        IsOpenDoor = !IsOpenDoor;
        _playableDirector.Play();
        yield return WaitForSeconds;
        _doorAudioSource.clip = _doorClip;
        _doorAudioSource.Play();

        while (_typeDoor.localPosition != newTarget)
        {
            _typeDoor.localPosition = Vector3.MoveTowards(_typeDoor.localPosition,
                newTarget, _speedOpenDoor * Time.deltaTime);
            yield return null;
        }

        _doorAudioSource.Stop();
        StopCoroutine(MoveDoor(newTarget));
    }

    private Vector3 GetNextTargetPosition()
    {
        return IsOpenDoor ? StartPositionDoor : NewPositionDoor;
    }
}