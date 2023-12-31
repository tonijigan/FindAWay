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

    private Vector3 _normal;
    private Rigidbody _rigidbody;
    private HaveGround _haveGround;
    private PlayerInput _input;
    private bool _isGround;


    private void Awake()
    {
        _input = new PlayerInput();
        _input.Enable();
    }

    private void Start()
    {
        _haveGround = GetComponent<HaveGround>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnFixedUpdate()
    {
        _isGround = _haveGround.Have();
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
            _playerInteractionSound.PlaySound(coin.AudioClip);
            coin.Did();
        }
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
        _playerAnimations.Move(direction, _isGround);
    }

    private Vector3 GetDirection()
    {
        int minPositionY = 0;
        var newPosition = _input.Player.Move.ReadValue<Vector2>();

        if (_isGround == true)
        {
            if (Application.isMobilePlatform == true)
                return new Vector3(_joystick.xAxis.value, minPositionY, _joystick.yAxis.value);
            else
                return new Vector3(newPosition.x, minPositionY, newPosition.y);
        }
        else
            return Vector3.zero;
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