using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private DynamicJoystick _dynamicJoystick;

    public event UnityAction RenderFall, NoRenderFall;

    private Vector3 _normal;
    private Rigidbody _rigidbody;

    private void Start() => _rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        var newDirection = GetDirection();
        Move(newDirection);
        MoveRotate(newDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
            _normal = collision.contacts[0].normal;

        if (collision.gameObject.TryGetComponent(out Ladder ladder))
            TriggerLadder(RenderFall, false);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ladder ladder))
            TriggerLadder(NoRenderFall, true);
    }

    private void TriggerLadder(UnityAction action, bool useGravity)
    {
        _rigidbody.useGravity = useGravity;
        action?.Invoke();
    }

    private Vector3 Project(Vector3 direction)
    {
        return direction - Vector3.Dot(direction, _normal) * _normal;
    }

    private void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = Project(direction.normalized);
        Vector3 offSet = _speed * Time.deltaTime * directionAlongSurface;
        _rigidbody.MovePosition(_rigidbody.position + offSet);
    }

    private Vector3 GetDirection()
    {
        int positionY = 0;
        return new Vector3(_dynamicJoystick.Horizontal, positionY, _dynamicJoystick.Vertical);
    }

    private void MoveRotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                 Quaternion.LookRotation(direction),
                                 _rotateSpeed * Time.deltaTime);
        }
    }
}