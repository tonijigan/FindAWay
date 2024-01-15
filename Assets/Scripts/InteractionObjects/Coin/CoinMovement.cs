using System.Collections;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private Transform _transform;

    private void Awake() => _transform = transform;

    public void Move(Transform target) => StartCoroutine(Moving(target));

    private IEnumerator Moving(Transform target)
    {
        float duration = 100f;

        while (_transform.localPosition != target.localPosition)
        {
            _transform.localPosition = Vector3.MoveTowards(_transform.localPosition,
                target.transform.localPosition, duration * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
        StopCoroutine(Moving(target));
    }
}