using System.Collections;
using UnityEngine;

public class PlayerInteractionObjectSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;
    private float _delayTime = 1;

    private void Start() => _waitForSeconds = new WaitForSeconds(_delayTime);

    public void PlaySound(AudioClip audioClip)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _audioSource.clip = audioClip;
        _coroutine = StartCoroutine(PlaySound());
    }

    private IEnumerator PlaySound()
    {
        _audioSource.Play();
        yield return _waitForSeconds;
        _audioSource.Stop();
        StopCoroutine(PlaySound());
    }
}