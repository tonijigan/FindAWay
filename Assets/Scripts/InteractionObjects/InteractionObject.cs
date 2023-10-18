using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class InteractionObject : MonoBehaviour
{
    protected Rigidbody Rigidbody;
    protected bool _isUse;

    public bool IsUse => _isUse;

    private void Start() => Rigidbody = GetComponent<Rigidbody>();

    public abstract void FollowInstructions();
}