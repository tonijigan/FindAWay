using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WalkSound : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start() => _audioSource = GetComponent<AudioSource>();

    public void PlayWalkSound() => _audioSource.Play();
}