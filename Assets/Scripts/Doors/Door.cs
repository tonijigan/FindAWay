using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Doors
{
    public abstract class Door : MonoBehaviour
    {
        [SerializeField] private Transform _type;
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private float _openingSpeed = 1f;
        [SerializeField] private float _waitForSeconds;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        private bool _isOpen;

        public bool IsOpen => _isOpen;
        protected WaitForSeconds WaitForSeconds { get; private set; }
        protected Coroutine Coroutine { get; private set; }
        protected Vector3 StartPosition { get; private set; }
        protected Vector3 NewPosition { get; private set; }
        protected Transform Type => _type;
        protected AudioSource AudioSource => _audioSource;
        protected AudioClip AudioClip => _audioClip;
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

        protected void SetPositions(Vector3 startPosition, Vector3 newPosition)
        {
            StartPosition = startPosition;
            NewPosition = newPosition;
        }

        protected void ChangeState() => _isOpen = !_isOpen;

        protected virtual IEnumerator Move(Vector3 newTarget)
        {
            _isOpen = !IsOpen;
            _playableDirector.Play();
            yield return WaitForSeconds;
            _audioSource.clip = _audioClip;
            _audioSource.Play();

            while (_type.localPosition != newTarget)
            {
                _type.localPosition = Vector3.MoveTowards(_type.localPosition, newTarget, _openingSpeed * Time.deltaTime);
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
}