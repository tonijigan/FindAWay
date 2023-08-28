using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start() => _rigidbody = GetComponent<Rigidbody>();

    public void EnableKinematic() => _rigidbody.isKinematic = true;
    public void DisableKinematic() => _rigidbody.isKinematic = false;
}