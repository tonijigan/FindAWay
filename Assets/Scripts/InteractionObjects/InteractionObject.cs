using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class InteractionObject : MonoBehaviour
{
    protected Rigidbody Rigidbody;

    private void Start() => Rigidbody = GetComponent<Rigidbody>();

    public abstract void FollowInstructions();
}
