using UnityEngine;
using UnityEngine.Events;

public class HaveGround : MonoBehaviour
{
    [SerializeField] private Transform _haveGroundPoint;
    [SerializeField] private float _radiusTriggerGround;
    [SerializeField] private LayerMask _layerMask;

    public event UnityAction Fall;

    private float _currentTimeFall = 0;
    private float _maxTime = 2f;
    private float _minTime = 0;

    public bool Have()
    {
        var isGround = Physics.CheckSphere(_haveGroundPoint.position, _radiusTriggerGround, _layerMask);

        if (isGround == false)
            Falling();
        else
            _currentTimeFall = _minTime;

        return isGround;
    }

    private void Falling()
    {
        if (_currentTimeFall > _maxTime)
        {
            _currentTimeFall = _minTime;
            Fall?.Invoke();
        }

        _currentTimeFall += Time.deltaTime;
    }
}