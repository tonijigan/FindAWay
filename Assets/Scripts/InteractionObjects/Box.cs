using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Box : InteractionObject
{
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    public override void FollowInstructions()
    {
        _isUse = true;
        _boxCollider.isTrigger = !_boxCollider.isTrigger;
        _rigidbody.isKinematic = !_rigidbody.isKinematic;
        _rigidbody.useGravity = !_rigidbody.useGravity;
    }

    public void ActiveObject() => _isUse = false;
}