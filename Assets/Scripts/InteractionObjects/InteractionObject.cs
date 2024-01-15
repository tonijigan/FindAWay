using UnityEngine;

public abstract class InteractionObject : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    protected bool _isUse;

    public Transform TransformObject { get; private set; }

    private void Awake() => TransformObject = transform;

    public AudioClip AudioClip => _audioClip;

    public bool IsUse => _isUse;

    public abstract void FollowInstructions();
}