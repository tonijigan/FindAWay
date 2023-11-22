using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private LaserSecurity _security;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Light _light;

    private Animator _animator;

    private void OnEnable() => _security.IsTrigger += Toggle;

    private void OnDisable() => _security.IsTrigger -= Toggle;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Toggle(bool isOpen)
    {
        if (isOpen == false)
            TurnOn();
    }

    private void TurnOn()
    {
        _audioSource.clip = _audioClip;
        _animator.SetBool(HashNames.Alarm, true);
        _light.gameObject.SetActive(true);
        _audioSource.Play();
    }
}