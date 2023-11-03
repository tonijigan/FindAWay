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
        float minTime = 0;
        bool isGround = Physics.CheckSphere(_haveGroundPoint.position, _radiusTriggerGround, _layerMask);

        if (isGround == false)
            Falling();
        else
            _timeFall = minTime;

        return isGround;
    }

    private void Falling()
    {
        float maxTime = 2f;

        if (_timeFall > maxTime)
            OnFall?.Invoke();

        _timeFall += Time.deltaTime;
    }
}