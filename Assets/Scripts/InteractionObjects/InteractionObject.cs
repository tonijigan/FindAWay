using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class InteractionObject : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    protected Rigidbody Rigidbody;
    protected bool _isUse;

    public AudioClip AudioClip => _audioClip;
    public bool IsUse => _isUse;

    private void Start() => Rigidbody = GetComponent<Rigidbody>();

    public abstract void FollowInstructions();
}