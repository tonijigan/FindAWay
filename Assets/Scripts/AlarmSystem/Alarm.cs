using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private LaserSecurity _security;
    [SerializeField] private Light _light;

    private Animator _animator;
    private AudioSource _audioSource;

    private void OnEnable() => _security.IsTrigger += Toggle;

    private void OnDisable() => _security.IsTrigger -= Toggle;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Toggle(bool isOpen)
    {
        if (isOpen == false)
            TurnOn();
    }

    private void TurnOn()
    {
        _animator.SetBool(HashNames.Alarm, true);
        _light.gameObject.SetActive(true);
        _audioSource.Play();
    }
}