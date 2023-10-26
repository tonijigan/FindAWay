using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private HashNames _names;
    [SerializeField] private InteractionWithObjects _interactionWithObjects;

    private Animator _animator;
    private InteractionObject _interactionObject;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Update() => _interactionObject = _interactionWithObjects.DragableObject;

    public void Move(Vector3 direction, bool haveGround)
    {
        Idle();
        Walk(direction);
        Falling(haveGround);
    }

    private void Falling(bool haveGround) => _animator.SetBool(_names.Falling, haveGround);

    private void Idle()
    {
        if (_interactionObject == null) return;

        if (_interactionObject.TryGetComponent(out Box box))
            _animator.SetBool(_names.IdleWhitBox, _interactionWithObjects.IsDragging);

        if (_interactionObject.TryGetComponent(out Key key))
            _animator.SetBool(_names.IdleWhitKey, _interactionWithObjects.IsDragging);
    }

    private void Walk(Vector3 direction)
    {
        _animator.SetFloat(_names.Walk, direction.magnitude);

        float magnitude = direction.magnitude;

        if (_interactionObject != null && _interactionWithObjects.IsDragging)
        {
            if (_interactionObject.TryGetComponent(out Box box))
                _animator.SetFloat(_names.WalkWhitBox, magnitude);

            if (_interactionObject.TryGetComponent(out Key key))
                _animator.SetFloat(_names.WalkWhitKey, magnitude);
        }
    }
}