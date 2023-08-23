using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private DynamicJoystick _dynamicJoystick;

    private Vector3 _normal;
    private Rigidbody _rigidbody;

    private void Start() => _rigidbody = GetComponent<Rigidbody>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
            _normal = collision.contacts[0].normal;
    }

    private Vector3 Project(Vector3 direction)
    {
        return direction - Vector3.Dot(direction, _normal) * _normal;
    }

    private void Update()
    {
        var newDirection = GetDirection();
        Move(newDirection);
        MoveRotate(newDirection);
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
