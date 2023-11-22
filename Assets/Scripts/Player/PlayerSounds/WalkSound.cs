using UnityEngine;

public class WalkSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public void PlayWalkSound()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}