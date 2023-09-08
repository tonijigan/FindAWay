using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AnimationNames _animationNames;
    [SerializeField] private LaserSecurity _security;
    [SerializeField] private ButtonObject _button;

    private Animator _animator;

    private void OnEnable()
    {
        _security.IsTrigger += Toggle;
        _button.ButtonClick += TurnOff;
    }

    private void OnDisable()
    {
        _security.IsTrigger -= Toggle;
        _button.ButtonClick -= TurnOff;
    }

    private void Awake() => _animator = GetComponent<Animator>();

    private void Toggle(bool isOpen)
    {
        if (isOpen == false)
            _animator.SetBool(_animationNames.Alarm, true);
        else
            _animator.SetBool(_animationNames.Alarm, false);
    }

    private void TurnOff(bool onClick) => _animator.SetBool(_animationNames.Alarm, false);
}