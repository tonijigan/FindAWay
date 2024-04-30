using System;
using System.Collections;
using Doors;
using InteractionObjects;
using UnityEngine;

namespace ButtonGameObject
{
    public class ButtonObject : MonoBehaviour
    {
        [SerializeField] private Door _door;
        [SerializeField] private Transform _boxPoint;
        [SerializeField] private AudioSource _audioSource;

        public event Action<int> ButtonActivated;

        private int _rewardPerClick = 1;
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
            if (!other.gameObject.TryGetComponent(out Box box)) return;
            ButtonActivated?.Invoke(_rewardPerClick);
            PlayCoroutine();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out Box box)) return;
            ButtonActivated?.Invoke(-_rewardPerClick);
            box.ActiveObject();
            PlayCoroutine();
        }

        private Vector3 GetPosition()
        {
            float positionZero = 0, newPositionY = -1f;
            var newPosition = _transform.localPosition + new Vector3(positionZero, newPositionY, positionZero);

            return IsClick == true ? newPosition : _startButtonPosition;
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
            var duration = 2f;
            _audioSource.Play();

            while (_transform.localPosition != newPosition)
            {
                _transform.localPosition = Vector3.MoveTowards(_transform.localPosition,
                    newPosition, duration * Time.deltaTime);
                yield return null;
            }

            _door.Work();
            yield return _waitForSeconds;
            _audioSource.Stop();
            StopCoroutine(ChangePosition(newPosition));
        }
    }
}