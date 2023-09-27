using System.Collections;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public void Move(Transform target) => StartCoroutine(Moving(target));

    private IEnumerator Moving(Transform target)
    {
        float duration = 100f;

        while (transform.localPosition != target.localPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.transform.localPosition, duration * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
        StopCoroutine(Moving(target));
    }
}