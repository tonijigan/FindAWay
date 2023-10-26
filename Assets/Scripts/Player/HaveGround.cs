using UnityEngine;
using UnityEngine.Events;

public class HaveGround : MonoBehaviour
{
    [SerializeField] private Transform _haveGroundPoint;
    [SerializeField] private float _radiusTriggerGround;
    [SerializeField] private LayerMask _layerMask;

    public event UnityAction OnFall;

    private float _timeFall = 0;

    public bool Have()
    {
        if (Physics.CheckSphere(_haveGroundPoint.position, _radiusTriggerGround, _layerMask))
        {
            return false;
        }
        else
        {
            Fall();
            return true;
        }
    }

    private void Fall()
    {
        float waitingTime = 2f;
        float minTime = 0;

        _timeFall += Time.deltaTime;

        if (_timeFall > waitingTime)
        {
            _timeFall = minTime;
            OnFall?.Invoke();
        }
    }
}