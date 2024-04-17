using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public abstract class Door : MonoBehaviour
{
    [SerializeField] protected Transform _type;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private float _openingSpeed = 1f, _waitForSeconds;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    protected Vector3 StartPosition, NewPosition;
    protected Coroutine Coroutine;
    protected WaitForSeconds WaitForSeconds;
    protected bool IsOpen;

    protected AudioSource AudioSource => _audioSource;
    protected AudioClip AudioClip => _audioClip;

    public bool IsOpened => IsOpen;

    protected PlayableDirector PlayableDirector => _playableDirector;

    private void Start()
    {
        SetPosition();
        WaitForSeconds = new WaitForSeconds(_waitForSeconds);
    }

    protected virtual void SetPosition() { }

    public void Work()
    {
        if (Coroutine != null)
            StopCoroutine(Coroutine);

        Coroutine = StartCoroutine(Move(GetNextTargetPosition()));
    }

    protected virtual IEnumerator Move(Vector3 newTarget)
    {
        IsOpen = !IsOpen;
        _playableDirector.Play();
        yield return WaitForSeconds;
        _audioSource.clip = _audioClip;
        _audioSource.Play();

        while (_type.localPosition != newTarget)
        {
            _type.localPosition = Vector3.MoveTowards(_type.localPosition,
                newTarget, _openingSpeed * Time.deltaTime);
            yield return null;
        }

        _audioSource.Stop();
        StopCoroutine(Move(newTarget));
    }

    private Vector3 GetNextTargetPosition()
    {
        return IsOpen ? StartPosition : NewPosition;
    }
}