using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private LaserSecurity _security;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private ParticleSystem _alarmEffect;

    private Animator _animator;

    private void OnEnable() => _security.IsTriggered += Toggle;

    private void OnDisable() => _security.IsTriggered -= Toggle;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Toggle(bool isOpen)
    {
        if (isOpen == false) TurnOn();
    }

    private void TurnOn()
    {
        _audioSource.clip = _audioClip;
        _animator.SetBool(HashedStrings.Alarm, true);
        _alarmEffect.Play();
        _audioSource.Play();
    }
}