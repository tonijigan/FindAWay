using UnityEngine;

[RequireComponent(typeof(CoinMovement))]
public class Coin : MonoBehaviour
{
    private CoinMovement _coinMovement;
    private Transform _target;

    private void Start() => _coinMovement = GetComponent<CoinMovement>();

    public int CoinValue { get; private set; } = 1;

    public void SetTarget(Transform transform) => _target = transform;

    public void Did() => _coinMovement.Move(_target);
}