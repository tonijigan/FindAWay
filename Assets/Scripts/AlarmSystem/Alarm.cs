using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Alarm : MonoBehaviour
{
    [SerializeField] LaserSecurity _security;
    [SerializeField] private ButtonObject _button;

    private const string AlarmAnimation = "Alarm";

    private Animator _animator;

    private void OnEnable()
    {
        _security.IsTrigger += Toggle;
        _button.OnDoorClick += TurnOff;
    }

    private void OnDisable()
    {
        _security.IsTrigger -= Toggle;
        _button.OnDoorClick -= TurnOff;
    }

    private void Awake() => _animator = GetComponent<Animator>();

    private void Toggle(bool isOpen)
    {
        if (isOpen == false)
            _animator.SetBool(AlarmAnimation, true);
        else
            _animator.SetBool(AlarmAnimation, false);
    }

    private void TurnOff(bool onClick) => _animator.SetBool(AlarmAnimation, false);
}
