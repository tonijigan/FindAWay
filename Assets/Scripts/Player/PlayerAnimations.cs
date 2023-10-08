using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private AnimationNames _names;
    [SerializeField] private InteractionWithObjects _interactionWithObjects;

    private Animator _animator;

    private InteractionObject _interactionObject;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Update()
    {
        _interactionObject = _interactionWithObjects.DragableObject;
    }

    public void Move(Vector3 direction)
    {
        Idle();
        Walk(direction);
    }

    private void Idle()
    {
        if (_interactionObject == null) return;

        if (_interactionObject.TryGetComponent(out Box box))
            _animator.SetBool(_names.IdleWhitBox, _interactionWithObjects.IsDragging);

        if (_interactionObject.TryGetComponent(out Key key))
            _animator.SetBool(_names.IdleWhitKey, _interactionWithObjects.IsDragging);
    }

    public void Falling() => _animator.SetBool(_names.Falling, true);

    private void Walk(Vector3 direction)
    {
        if (_interactionObject == null) _animator.SetFloat(_names.Walk, direction.magnitude);

        HaveInteractionObject(direction);
    }

    private void HaveInteractionObject(Vector3 direction)
    {
        float magnitude = direction.magnitude;

        if (_interactionWithObjects.IsDragging)
        {
            if (_interactionObject.TryGetComponent(out Box box))
                _animator.SetFloat(_names.WalkWhitBox, magnitude);

            if (_interactionObject.TryGetComponent(out Key key))
                _animator.SetFloat(_names.WalkWhitKey, magnitude);
        }

        _animator.SetFloat(_names.Walk, magnitude);
    }
}