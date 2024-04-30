using UnityEngine;

namespace InteractionObjects.Coin
{
    [RequireComponent(typeof(CoinMovement))]
    public class Coin : InteractionObject
    {
        private CoinMovement _coinMovement;
        private Transform _target;

        private void Start() => _coinMovement = GetComponent<CoinMovement>();

        public void SetTarget(Transform target) => _target = target;

        public void Move() => _coinMovement.Move(_target);
    }
}