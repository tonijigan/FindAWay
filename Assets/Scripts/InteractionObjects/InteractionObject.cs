using UnityEngine;

namespace InteractionObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class InteractionObject : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private ParticleSystem _effect;

        private bool _isUse;

        private Rigidbody _rigidbody;

        public Transform TransformObject => transform;
        public Rigidbody RigidbodyObject => _rigidbody;
        public AudioClip AudioClip => _audioClip;
        public bool IsUse => _isUse;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void ActiveObject() => _isUse = false;

        public void PickUp()
        {
            _isUse = true;
            _rigidbody.useGravity = false;

            if (_effect == null) return;

            _effect.Play();
        }

        public void PutDown()
        {
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = true;
            TransformObject.rotation = Quaternion.identity;
            _rigidbody.isKinematic = false;

            if (_effect == null) return;

            _effect.Stop();
        }
    }
}