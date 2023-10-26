using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(AudioSource))]
public abstract class AbstractDoor : MonoBehaviour
{
    [SerializeField] protected Transform _typeDoor;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private float _speedOpenDoor = 1f, _waitForSecondsTime;

    protected Vector3 StartPositionDoor, NewPositionDoor;
    protected AudioSource DoorAudioSource;
    protected Coroutine Coroutine;
    protected bool IsOpenDoor;
    protected WaitForSeconds WaitForSeconds;


    public bool IsOpen => IsOpenDoor;

    private void Start()
    {
        SetPosition();
        WaitForSeconds = new WaitForSeconds(_waitForSecondsTime);
        DoorAudioSource = GetComponent<AudioSource>();
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

    public virtual IEnumerator MoveDoor(Vector3 newTarget)
    {
        IsOpenDoor = !IsOpenDoor;
        _playableDirector.Play();
        yield return WaitForSeconds;
        DoorAudioSource.Play();

        while (_typeDoor.localPosition != newTarget)
        {
            _typeDoor.localPosition = Vector3.MoveTowards(_typeDoor.localPosition, newTarget, _speedOpenDoor * Time.deltaTime);
            yield return null;
        }

        DoorAudioSource.Stop();
        StopCoroutine(MoveDoor(newTarget));
    }
}