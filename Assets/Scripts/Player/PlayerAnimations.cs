using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private InteractionObject _interactionObject;
    private bool _isDragging = false;

    private void Awake() => _animator = GetComponent<Animator>();


    public void OnUpdate(InteractionObject interactionObject, bool isDragging)
    {
        _interactionObject = interactionObject;
        _isDragging = isDragging;
    }

    public void Move(Vector3 direction, bool haveGround)
    {
        Idle();
        Walk(direction);
        Falling(haveGround);
    }

    private void Falling(bool haveGround)
    {
        float duration = 0.1f;

        if (haveGround == false)
            _animator.CrossFade(HashedStrings.Falling, duration);
    }

    private void Idle()
    {
        if (_interactionObject == null)
        {
            _animator.SetBool(HashedStrings.IdleWhitBox, _isDragging);
            _animator.SetBool(HashedStrings.IdleWhitKey, _isDragging);
            return;
        }

        if (_interactionObject.TryGetComponent(out Box box))
            _animator.SetBool(HashedStrings.IdleWhitBox, _isDragging);

        if (_interactionObject.TryGetComponent(out Key key))
            _animator.SetBool(HashedStrings.IdleWhitKey, _isDragging);
    }

    private void Walk(Vector3 direction)
    {
        _animator.SetFloat(HashedStrings.Walk, direction.magnitude);

        float magnitude = direction.magnitude;

        if (_interactionObject == null || !_isDragging) return;
        if (_interactionObject.TryGetComponent(out Box box))
            _animator.SetFloat(HashedStrings.WalkWhitBox, magnitude);

        if (_interactionObject.TryGetComponent(out Key key))
            _animator.SetFloat(HashedStrings.WalkWhitKey, magnitude);
    }
}