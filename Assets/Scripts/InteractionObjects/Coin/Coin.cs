using UnityEngine;

[RequireComponent(typeof(CoinMovement), typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    private AudioSource _coinSource;
    private CoinMovement _coinMovement;
    private Transform _target;

    private void Start()
    {
        _coinSource = GetComponent<AudioSource>();
        _coinMovement = GetComponent<CoinMovement>();
    }

    public int CoinValue { get; private set; } = 1;

    public void SetTarget(Transform transform) => _target = transform;

    public void PlaySound() => _coinSource.Play();

    public void Did() => _coinMovement.Move(_target);
}