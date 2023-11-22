using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : InteractionObject
{
    private Rigidbody _rigidbody;

    private void Start() => _rigidbody = GetComponent<Rigidbody>();

    public override void FollowInstructions()
    {
        _isUse = true;
        _rigidbody.isKinematic = !_rigidbody.isKinematic;
        _rigidbody.useGravity = !_rigidbody.useGravity;
    }
}