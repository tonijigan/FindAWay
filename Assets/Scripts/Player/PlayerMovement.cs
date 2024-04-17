using SimpleInputNamespace;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(HaveGround))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private PlayerInteractionObjectSound _playerInteractionSound;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private LayerMask _layerMask;

    private Transform _transform;
    private Vector3 _normal;
    private Rigidbody _rigidbody;
    private HaveGround _haveGround;
    private PlayerInput _input;
    private bool _isGround = true;


    private void Awake()
    {
        _haveGround = GetComponent<HaveGround>();
        _rigidbody = GetComponent<Rigidbody>();
        _input = new PlayerInput();
        _input.Enable();
        _transform = transform;
    }

    public void OnFixedUpdate()
    {
        _isGround = _haveGround.IsGround();
        var newDirection = GetDirection();
        Move(newDirection);
        MoveRotate(newDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _layerMask)
            _normal = collision.contacts[0].normal;
    }

    private void OnTriggerEnter(Collider other) => CollisionWithCoin(other);

    private void CollisionWithCoin(Collider interactionObject)
    {
        if (!interactionObject.TryGetComponent(out Coin coin)) return;

        interactionObject.enabled = false;
        _playerWallet.AddCoin(coin);
        _playerInteractionSound.PlaySound(coin.AudioClip);
        coin.Move();
    }

    private Vector3 DirectionAlongSurface(Vector3 direction)
    {
        return direction - Vector3.Dot(direction, _normal) * _normal;
    }

    private void Move(Vector3 direction)
    {
        var directionAlongSurface = DirectionAlongSurface(direction.normalized);
        var offSet = _speed * Time.fixedDeltaTime * directionAlongSurface;
        _rigidbody.MovePosition(_rigidbody.position + offSet);
        _playerAnimations.Move(direction, _isGround);
    }

    private Vector3 GetDirection()
    {
        var minPositionY = 0;
        var newPosition = _input.Player.Move.ReadValue<Vector2>();

        if (_isGround == true)
        {
            return Application.isMobilePlatform == true
                ? new Vector3(_joystick.xAxis.value, minPositionY, _joystick.yAxis.value)
                : new Vector3(newPosition.x, minPositionY, newPosition.y);
        }
        else
            return Vector3.zero;
    }

    private void MoveRotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            _transform.rotation = Quaternion.Lerp(_transform.rotation,
                Quaternion.LookRotation(direction),
                _rotateSpeed * Time.fixedDeltaTime);
        }
    }
}