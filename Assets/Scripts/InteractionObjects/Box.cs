using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start() => _rigidbody = GetComponent<Rigidbody>();

    public void PrepareForDrag()
    {
        _rigidbody.useGravity = false;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }
}
