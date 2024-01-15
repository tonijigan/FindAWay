using UnityEngine;

[RequireComponent(typeof(CoinMovement))]
public class Coin : InteractionObject
{
    private CoinMovement _coinMovement;
    private Transform _target;

    private void Start() => _coinMovement = GetComponent<CoinMovement>();

    public void SetTarget(Transform transform) => _target = transform;

    public void Did() => _coinMovement.Move(_target);

    public override void FollowInstructions(){}
}