using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _dynamicJoystick;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Transform _haveGroundPoint;
    [SerializeField] private float _radiusTriggerGround;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private LayerMask _layerMask;

    private Vector3 _normal;
    private Rigidbody _rigidbody;

    private void Start() => _rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        HaveGround();
        var newDirection = GetDirection();
        Move(newDirection);
        MoveRotate(newDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _layerMask)
            _normal = collision.contacts[0].normal;
    }

    private void OnTriggerEnter(Collider other) => HaveTriggerCoin(other);

    private void HaveTriggerCoin(Collider collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            collider.enabled = false;
            _playerWallet.AddCoin(coin);
            coin.Did();
        }
    }

    private bool HaveGround()
    {
        if (Physics.CheckSphere(_haveGroundPoint.position, _radiusTriggerGround, _layerMask)) return false;
        else return true;
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
        _playerAnimations.Move(direction, HaveGround());
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