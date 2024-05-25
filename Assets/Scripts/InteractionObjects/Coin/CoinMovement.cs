using System.Collections;
using UnityEngine;

namespace InteractionObjects.Coin
{
    public class CoinMovement : MonoBehaviour
    {
        private Transform _transform;
        private GameObject _gameObject;

        private void Awake()
        {
            _gameObject = gameObject;
            _transform = transform;
        }

        public void Move(Transform target) => StartCoroutine(Moving(target));

        private IEnumerator Moving(Transform target)
        {
            float duration = 100f;

            while (_transform.localPosition != target.localPosition)
            {
                _transform.localPosition = Vector3.MoveTowards(_transform.localPosition, target.transform.localPosition, duration * Time.deltaTime);
                yield return null;
            }

            _gameObject.SetActive(false);
            StopCoroutine(Moving(target));
        }
    }
}