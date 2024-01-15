using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    [SerializeField] private AbstractDoor _door;
    [SerializeField] private Transform _boxPoint;
    [SerializeField] private AudioSource _audioSource;

    public event UnityAction<bool> ButtonClick;

    private Transform _transform;
    private Coroutine _coroutine;
    private Vector3 _startButtonPosition;
    private WaitForSeconds _waitForSeconds;
    private float _waitTime = 1.0f;

    public Transform BoxPoint => _boxPoint;
    public bool IsClick { get; private set; } = false;

    private void Awake()
    {
        _transform = transform;
        _startButtonPosition = _transform.localPosition;
        _waitForSeconds = new WaitForSeconds(_waitTime);
    }
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
        var newPosition = _transform.localPosition + new Vector3(positionZero, newPositionY, positionZero);

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
        _audioSource.Play();

        while (_transform.localPosition != newPosition)
        {
            _transform.localPosition = Vector3.MoveTowards(_transform.localPosition,
                                      newPosition, duration * Time.deltaTime);
            yield return null;
        }

        ButtonClick?.Invoke(IsClick);
        _door.WorkDoor();
        yield return _waitForSeconds;
        _audioSource.Stop();
        StopCoroutine(ChangePosition(newPosition));
    }
}