using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class InteractionObject : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    protected bool _isUse;

    private Rigidbody _rigidbody;

    public Transform TransformObject => transform;
    public Rigidbody RigidbodyObject => _rigidbody;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    public AudioClip AudioClip => _audioClip;

    public bool IsUse => _isUse;

    public void ActiveObject() => _isUse = false;

    public void TryPickUp()
    {
        _isUse = true;
        _rigidbody.useGravity = false;
    }

    public void PutDown()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = true;
        TransformObject.rotation = Quaternion.identity;
        _rigidbody.isKinematic = false;
    }
}