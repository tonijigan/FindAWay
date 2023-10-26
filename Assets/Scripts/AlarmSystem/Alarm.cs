using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private HashNames _animationNames;
    [SerializeField] private LaserSecurity _security;
    [SerializeField] private ButtonObject _button;
    [SerializeField] private Light _light;

    private Animator _animator;
    private AudioSource _audioSource;

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

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Toggle(bool isOpen)
    {
        if (isOpen == false)
            TurnOn();
        else
            TurnOff();
    }

    private void TurnOn()
    {
        _animator.SetBool(_animationNames.Alarm, true);
        _light.gameObject.SetActive(true);
        _audioSource.Play();
    }

    private void TurnOff(bool isClick = false)
    {
        _audioSource.Stop();
        _animator.SetBool(_animationNames.Alarm, false);
        _light.gameObject.SetActive(false);
    }
}